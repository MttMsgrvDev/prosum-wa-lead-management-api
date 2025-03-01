using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Sort;

/// <summary>
/// Parses sort strings.
/// </summary>
public interface ISortStringParser
{

    /// <summary>
    /// Parses the given sort string and returns a set of sorting options.
    /// </summary>
    /// <param name="sortString">The sort string to be parsed.</param>
    /// <returns>A set of sorting options.</returns>
    SortOptions Parse(string sortString);

}