namespace LeadManagermentApi.DTOs;

/// <summary>
/// The include options for a query.
/// </summary>
/// <param name="PropertyIncludes">The properties to include in the returned records.</param>
public record IncludeOptions(
    IEnumerable<string>? PropertyIncludes = null);