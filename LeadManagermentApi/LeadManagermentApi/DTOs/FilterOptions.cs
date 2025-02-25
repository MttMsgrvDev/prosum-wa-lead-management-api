namespace LeadManagermentApi.DTOs;

/// <summary>
/// Filtering options for a query.
/// </summary>
/// <param name="Filters">The filters to be applied.</param>
public record FilterOptions(
    IEnumerable<FieldFilter> Filters);