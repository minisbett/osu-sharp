using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace osu.NET.Analyzers
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public class MissingErrorAttributeAnalyzer : DiagnosticAnalyzer
  {
#pragma warning disable IDE0079
#pragma warning disable RS2008
    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor("OSU002", "Unhandled API error type",
      "The API endpoint method is missing the [CanReturnAPIError] attribute", "Usage", DiagnosticSeverity.Error, true,
      "Ensures all API endpoint methods have the [CanReturnAPIError] attribute.");

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.EnableConcurrentExecution();
      context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.MethodDeclaration);
    }

    private void Analyze(SyntaxNodeAnalysisContext context)
    {
      // Ignore the GetAsync method that's responsible for sending all requests internally.
      MethodDeclarationSyntax methodDeclaration = context.Node as MethodDeclarationSyntax;
      if (methodDeclaration.Identifier.ValueText == "GetAsync")
        return;
      // Check it the method is in the OsuApiClient class in the osu-sharp namespace.
      if (!(methodDeclaration.Parent is ClassDeclarationSyntax classDeclaration))
        return;
      if (classDeclaration.Identifier.ValueText != "OsuApiClient")
        return;
      if (!(classDeclaration.Parent is BaseNamespaceDeclarationSyntax namespaceDeclaration))
        return;
      QualifiedNameSyntax qualifiedName = namespaceDeclaration.Name as QualifiedNameSyntax;
      IdentifierNameSyntax left = qualifiedName.Left as IdentifierNameSyntax;
      IdentifierNameSyntax right = qualifiedName.Right as IdentifierNameSyntax;
      if (left.Identifier.ValueText + "." + right.Identifier.ValueText != "osu.NET")
        return;


      // Check if the method returns an APIResult<T>
      if (!(methodDeclaration.ReturnType is GenericNameSyntax returnType))
        return;
      if (returnType.Identifier.ValueText != "Task")
        return;
      if (returnType.TypeArgumentList.Arguments.Count != 1 || !(returnType.TypeArgumentList.Arguments[0] is GenericNameSyntax argument))
        return;
      if (argument.Identifier.ValueText != "APIResult")
        return;

      // Check if the method has a [CanReturnAPIError] attribute
      AttributeSyntax[] attributes = methodDeclaration.AttributeLists.SelectMany(x => x.Attributes).ToArray();
      if (attributes.Any(x => ((IdentifierNameSyntax)x.Name).Identifier.ValueText == "CanReturnAPIError"))
        return;

      Diagnostic diagnostic = Diagnostic.Create(Rule, methodDeclaration.GetLocation());
      context.ReportDiagnostic(diagnostic);
    }
  }
}