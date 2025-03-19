using System.Diagnostics.CodeAnalysis;

namespace osu.NET;

/// <summary>
/// Represents a result from an osu! API request.
/// </summary>
/// <typeparam name="T">The return type of the endpoint.</typeparam>
public class APIResult<T> where T : class
{
  /// <summary>
  /// Creates a successful <see cref="APIResult{T}"/> with the specified returned value.
  /// </summary>
  /// <param name="value">The value returned by the osu! API.</param>
  internal APIResult(T? value)
  {
    Value = value;
  }

  /// <summary>
  /// Creates a successful <see cref="APIResult{T}"/> with the specified error.
  /// </summary>
  /// <param name="error">The error returned by the osu! API.</param>
  internal APIResult(APIError error)
  {
    ArgumentNullException.ThrowIfNull(error, nameof(error));

    Error = error;
  }

  /// <summary>
  /// The value returned by the osu! API. If the result indicates an error, accessing this value will throw an exception.
  /// </summary>
  public T? Value
  {
    get
    {
      if (IsFailure)
        throw new InvalidOperationException($"Cannot access the value of a failed {nameof(APIResult<T>)}.");

      return field;
    }
  }

  /// <summary>
  /// The error returned by the osu! API. This will be null if the request was successful.
  /// </summary>
  public APIError? Error { get; }

  /// <summary>
  /// Bool whether the request was successful.
  /// </summary>
  [MemberNotNullWhen(false, nameof(Error))]
  public bool IsSuccess => Error is null;

  /// <summary>
  /// Bool whether the request failed.
  /// </summary>
  [MemberNotNullWhen(true, nameof(Error))]
  public bool IsFailure => !IsSuccess;

  /// <summary>
  /// Sets the <see cref="APIErrorType"/> of the <see cref="Error"/> to the specified error type if the API result indicates <see cref="APIErrorType.Null"/>.
  /// </summary>
  /// <param name="errorType">The error to replace <see cref="APIErrorType.Null"/> with.</param>
  internal APIResult<T> WithErrorFallback(APIErrorType errorType)
  {
    if (Error?.Type is APIErrorType.Null)
      Error.Type = errorType;

    return this;
  }

  /// <summary>
  /// Matches the API result to execute the corresponding success or error handler.
  /// </summary>
  /// <param name="success">Executed if the API request was successful, receiving the value.</param>
  /// <param name="error">Executed if the API request failed, receiving the error.</param>
  public void Match(Action<T?> success, Func<APIError, Action> error)
  {
    if (IsSuccess)
      success(Value);
    else
      error(Error)();
  }

  /// <summary>
  /// Matches the API result to execute the corresponding success or error handler, returning a value of type <typeparamref name="TReturn"/>.
  /// </summary>
  /// <param name="success">Executed if the API request was successful, receiving the value.</param>
  /// <param name="error">Executed if the API request failed, receiving the error.</param>
  public TReturn Match<TReturn>(Func<T?, TReturn> success, Func<APIError, Func<TReturn>> error)
  {
    return IsSuccess ? success(Value) : error(Error)();
  }

  public static implicit operator APIResult<T>(APIError error) => new(error);

  public static implicit operator APIResult<T>(T? value) => new(value);
}