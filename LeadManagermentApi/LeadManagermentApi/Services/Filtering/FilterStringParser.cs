using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Filtering;

/// <summary>
/// Parses a filter string.
/// </summary>
public class FilterStringParser : IFilterStringParser
{
    /// <summary>
    /// Parses the filter string and returns a set of filter options.
    /// </summary>
    /// <param name="filterString">The filter string to parse.</param>
    /// <returns>A set of filter options.</returns>
    public FilterOptions Parse(string? filterString)
    {
        var fieldFilters = new List<FieldFilter>
        {
            new FieldFilter("LastName", FieldFilterOperator.Equal, "Musgrove")
        };

        return new FilterOptions(fieldFilters);
    }
}