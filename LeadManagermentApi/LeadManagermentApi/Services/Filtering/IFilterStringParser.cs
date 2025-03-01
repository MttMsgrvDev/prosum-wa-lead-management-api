using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Filtering;

/// <summary>
/// Parses a filter string.
/// </summary>
public interface IFilterStringParser
{

    /// <summary>
    /// Parses the filter string and returns a set of filter options.
    /// </summary>
    /// <param name="filterString">The filter string to parse.</param>
    /// <returns>A set of filter options.</returns>
    FilterOptions Parse(string? filterString);

}