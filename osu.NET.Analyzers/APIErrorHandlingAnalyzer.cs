using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace osu.NET.Analyzers
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public class APIErrorHandlingAnalyzer : DiagnosticAnalyzer
  {
#pragma warning disable IDE0079
#pragma warning disable RS2008
    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor("OSU001", "Unhandled API error type",
      "The API error type '{0}' may be returned from '{1}' but is unhandled", "Usage", DiagnosticSeverity.Warning, true,
      "Ensures all API error types are handled on osu! API calls.");

    private SyntaxNodeAnalysisContext _context;

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.EnableConcurrentExecution();
      context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.ExpressionStatement);
    }

    private void Analyze(SyntaxNodeAnalysisContext context)
    {
      _context = context;

      // Check whether this expression statement is a method invocation of .Match on an APIResult<T>.
      InvocationExpressionSyntax matchInvocation = ((ExpressionStatementSyntax)context.Node).Expression as InvocationExpressionSyntax;
      if (!IsValidResultMatchInvocation(matchInvocation, out string variableName, out SwitchExpressionSyntax matchErrorSwitchExpression))
        return;

      // Go through all statements until the .Match call in reverse order, trying to find the API call that set the variable .Match is called on.
      // Note: This only checks for API calls on the same indention level, as a deeper level cannot ensure the variable origins from that call.
      IMethodSymbol apiCallMethod = null;
      foreach (StatementSyntax statement in GetStatementsUntil(matchInvocation.FirstAncestorOrSelf<BlockSyntax>(), matchInvocation).Reverse())
        if (IsValidAPICall(statement, variableName, out IMethodSymbol method))
        {
          apiCallMethod = method;
          break;
        }

      // Ensure the API call was found and has a [CanReturnAPIError] attribute. If so, get the errors to be expected.
      if (apiCallMethod is null)
        return;
      if (!(apiCallMethod.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == "CanReturnAPIErrorAttribute") is AttributeData attribute))
        return;
      string[] expectedErrors = attribute.ConstructorArguments[0].Values.Select(x => (int)x.Value)
        .Where(x => x < Enum.GetValues(typeof(APIErrorType)).Length).Select(x => ((APIErrorType)x).ToString()).ToArray();

      // Go through the arms of the switch expression of the .Match error handler and 
      List<string> handledErrors = new List<string>();
      foreach (SwitchExpressionArmSyntax arm in matchErrorSwitchExpression.Arms)
        if (IsValidSwitchArm(arm, out string error))
          handledErrors.Add(error);

      // Report a diagnostic for every unhandled error.
      foreach (string missingError in expectedErrors.Except(handledErrors))
      {
        Diagnostic diagnostic = Diagnostic.Create(Rule, matchErrorSwitchExpression.Parent.GetLocation(), missingError, apiCallMethod.Name);
        context.ReportDiagnostic(diagnostic);
      }
    }

    /// <summary>
    /// Returns whether the specified invocation is a valid .Match call on an APIResult object.
    /// <br/><br/>
    /// Additionally, the following checks are performed:<br/>
    /// - The second parameter of the .Match call is a lambda expression containing a switch expression.<br/>
    /// - The switch expression targets the .Type property of the APIError lambda parameter.
    /// <br/><br/>
    /// The name of the variable the .Match call is called on and the switch expression is returned in the out-parameters.
    /// </summary>
    private bool IsValidResultMatchInvocation(InvocationExpressionSyntax invocation, out string variableName, out SwitchExpressionSyntax switchExpression)
    {
      variableName = null;
      switchExpression = null;

      // Check if the invocation is a method call to APIResult<T>.Match.
      if (invocation is null)
        return false;
      if (!(_context.SemanticModel.GetSymbolInfo(invocation).Symbol is IMethodSymbol method))
        return false;
      if (method.Name != "Match" || method.ReceiverType.Name != "APIResult")
        return false;
      if(method.ContainingNamespace.Name != "NET" || method.ContainingNamespace.ContainingNamespace?.Name != "osu")
        return false;

      // Get the variable name of the variable .Match is called on.
      MemberAccessExpressionSyntax memberAccess = invocation.Expression as MemberAccessExpressionSyntax;
      IdentifierNameSyntax variableIdentifier = memberAccess?.Expression as IdentifierNameSyntax
        ?? (memberAccess?.Expression as ParenthesizedExpressionSyntax)?.Expression as IdentifierNameSyntax;
      if (variableIdentifier != null)
        variableName = variableIdentifier.Identifier.ValueText;
      else
        return false;

      // Check if the second parameter of the Match method is a simple lambda expression which contains a switch expression.
      if (!(invocation.ArgumentList.Arguments[1].Expression is SimpleLambdaExpressionSyntax exprLambda))
        return false;
      if (!(exprLambda.Body is SwitchExpressionSyntax exprSwitch))
        return false;

      // Check if the switch expression targets the .Type property of the APIError lambda parameter.
      if (!(exprSwitch.GoverningExpression is MemberAccessExpressionSyntax exprErrorTypeAccess))
        return false;
      if (!(exprErrorTypeAccess.Name is IdentifierNameSyntax memberIdentifier) || memberIdentifier.Identifier.ValueText != "Type")
        return false;
      if (!(exprErrorTypeAccess.Expression is IdentifierNameSyntax errorIdentifier) || errorIdentifier.Identifier.ValueText != exprLambda.Parameter.Identifier.ValueText)
        return false;

      switchExpression = exprSwitch;
      return true;
    }

    /// <summary>
    /// Returns whether the specified statement is an osu.NET API call, assigning the result to the variable with the specified name.
    /// <br/><br/>
    /// The API call method symbol is returned in the out-parametes.
    /// </summary>
    private bool IsValidAPICall(StatementSyntax statement, string variableName, out IMethodSymbol apiCallMethod)
    {
      apiCallMethod = null;

      InvocationExpressionSyntax apiCallInvocation = null;

      // Handle when the result is assigned to an already delcared variable (result = await ...).
      if (statement is ExpressionStatementSyntax expression)
      {
        if (!(expression.Expression is AssignmentExpressionSyntax assignment))
          return false;
        // Check whether the variable the API call assigns to is the same type as the variable .Match is called on.
        if (!(assignment.Left is IdentifierNameSyntax assignedVariableName) || assignedVariableName.Identifier.ValueText != variableName)
          return false;
        if (!(assignment.Right is AwaitExpressionSyntax await))
          return false;
        if (!(await.Expression is InvocationExpressionSyntax methodInvocation))
          return false;

        apiCallInvocation = methodInvocation;
      }
      // Handle when the result is assigned to a newly declared variable (APIResult<T> result = await ...).
      else if (statement is LocalDeclarationStatementSyntax local)
      {
        if (!(local.Declaration is VariableDeclarationSyntax declaration))
          return false;
        if (declaration.Variables.Count != 1 || !(declaration.Variables[0] is VariableDeclaratorSyntax declarator))
          return false;
        // Check whether the variable the API call assigns to is the same type as the variable .Match is called on.
        if (!(declarator.Identifier is SyntaxToken declaredVariableName) || declaredVariableName.ValueText != variableName)
          return false;
        if (!(declarator.Initializer is EqualsValueClauseSyntax equals))
          return false;
        if (!(equals.Value is AwaitExpressionSyntax await))
          return false;
        if (!(await.Expression is InvocationExpressionSyntax methodInvocation))
          return false;

        apiCallInvocation = methodInvocation;
      }

      // Check whether a method call was found and if so, whether the returned type is an APIResult and the method from the osu.NET namespace.
      if (apiCallInvocation == null)
        return false;
      if (!(_context.SemanticModel.GetSymbolInfo(apiCallInvocation).Symbol is IMethodSymbol method))
        return false;
      if (method.ContainingNamespace.Name != "NET" || method.ContainingNamespace.ContainingNamespace?.Name != "osu")
        return false;
      if (!(method.ReturnType is INamedTypeSymbol namedSymbol) || !namedSymbol.TypeArguments.Any(x => x.Name == "APIResult"))
        return false;

      apiCallMethod = method;
      return true;
    }

    /// <summary>
    /// Returns whether the specified switch expression arm is a check for an APIErrorType.
    /// <br/><br/>
    /// The name of the APIErrorType is returned in the out-parameter.
    /// </summary>
    private bool IsValidSwitchArm(SwitchExpressionArmSyntax arm, out string error)
    {
      error = null;

      if (!(arm.Pattern is ConstantPatternSyntax pattern))
        return false;
      if (!(pattern.Expression is MemberAccessExpressionSyntax memberAccess))
        return false;
      if (!(memberAccess.Expression is IdentifierNameSyntax enumName) || enumName.Identifier.ValueText != "APIErrorType")
        return false;
      if (!(memberAccess.Name is SimpleNameSyntax errorName))
        return false;

      error = errorName.Identifier.ValueText;
      return true;
    }

    /// <summary>
    /// Returns all statements in the block until the specified node (excluding it).
    /// </summary>
    /// <param name="block">The code block.</param>
    /// <param name="node">The node up until which is returned.</param>
    /// <returns>The statements in the code block until the specified node.</returns>
    private IEnumerable<StatementSyntax> GetStatementsUntil(BlockSyntax block, CSharpSyntaxNode node)
    {
      foreach (StatementSyntax statement in block.Statements)
      {
        if (statement.SpanStart >= node.SpanStart)
          yield break;

        yield return statement;
      }
    }
  }
}