namespace LeadManagermentApi.Exceptions.Validation;

/// <summary>
/// Represents a validation error.
/// </summary>
/// <param name="PropertyName">The name of the property that caused the validation error.</param>
/// <param name="Message">The error message.</param>
public record ValidationError(string PropertyName, string Message);