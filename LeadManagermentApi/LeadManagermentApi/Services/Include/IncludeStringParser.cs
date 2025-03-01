using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Include;

/// <summary>
/// Parses include strings.
/// </summary>
public class IncludeStringParser : IIncludeStringParser
{
    /// <summary>
    /// Parses an include string and returns the IncludeOptions.
    /// </summary>
    /// <param name="includeString">The string to parse.</param>
    /// <returns>The include options.</returns>
    public IncludeOptions Parse(string? includeString)
    {
        var propertyIncludes = new List<string>
        {
            "Contact"
        };

        return new IncludeOptions(propertyIncludes);
    }
}