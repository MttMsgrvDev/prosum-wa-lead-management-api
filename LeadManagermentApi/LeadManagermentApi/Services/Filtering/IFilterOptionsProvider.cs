using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Filtering;

/// <summary>
/// Provides a set of filters
/// </summary>
public interface IFilterOptionsProvider
{
    /// <summary>
    /// Retrieves the set of filters.
    /// </summary>
    /// <returns>A set of filters.</returns>
    FilterOptions GetFilters();
}