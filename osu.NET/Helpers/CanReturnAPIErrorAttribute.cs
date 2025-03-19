namespace osu.NET.Helpers;

#pragma warning disable CS9113 

/// <summary>
/// Specifies that the method can return the specified <see cref="APIErrorType"/>s.
/// This attribute is used for the error handling code analyzer.
/// </summary>
/// <param name="errorTypes">The API error types that can be returned.</param>
[AttributeUsage(AttributeTargets.Method)]
public class CanReturnAPIErrorAttribute(params APIErrorType[] errors) : Attribute;