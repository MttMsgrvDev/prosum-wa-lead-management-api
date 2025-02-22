namespace LeadManagermentApi.Exceptions.Http;

/// <summary>
/// Represents an HTTP exception.
/// </summary>
public class HttpException : Exception
{
    /// <summary>
    /// An error title to use when reporting back to the user.
    /// </summary>
    public string ErrorTitle { get; set; }

    /// <summary>
    /// The status code for the exception.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Creates a new instance of HttpException.
    /// </summary>
    /// <param name="statusCode">The status code for the exception.</param>
    /// <param name="errorTitle">A title for the error.</param>
    /// <param name="message">The error message.</param>
    /// <param name="exception">The exception that occured.</param>
    public HttpException(int statusCode, string errorTitle, string message, Exception exception) : base(message, exception)
    {
        ErrorTitle = errorTitle;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Creates a new instance of HttpException.
    /// </summary>
    /// <param name="statusCode">The status code for the exception.</param>
    /// <param name="errorTitle">A title for the error.</param>
    /// <param name="message">The error message.</param>
    public HttpException(int statusCode, string errorTitle, string message) : base(message)
    {
        ErrorTitle = errorTitle;
        StatusCode = statusCode;
    }
}