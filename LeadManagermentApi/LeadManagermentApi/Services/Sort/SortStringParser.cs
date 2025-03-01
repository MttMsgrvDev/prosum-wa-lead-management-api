using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Sort;

/// <summary>
/// Parses sort strings.
/// </summary>
public class SortStringParser : ISortStringParser
{
    /// <summary>
    /// Parses the given sort string and returns a set of sorting options.
    /// </summary>
    /// <param name="sortString">The sort string to be parsed.</param>
    /// <returns>A set of sorting options.</returns>
    public SortOptions Parse(string sortString)
    {
        var sortFields = new List<KeyValuePair<string, SortDirection>>
        {
            new KeyValuePair<string, SortDirection>("LastName", SortDirection.Ascending)
        };

        return new SortOptions(sortFields);
    }
}