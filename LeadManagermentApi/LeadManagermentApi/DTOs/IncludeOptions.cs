namespace LeadManagermentApi.DTOs;

/// <summary>
/// The include options for a query.
/// </summary>
/// <param name="propertyIncludes">The properties to include in the returned records.</param>
public record IncludeOptions(
    IEnumerable<string>? propertyIncludes = null);