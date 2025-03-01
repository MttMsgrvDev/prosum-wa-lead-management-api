using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Include;

/// <summary>
/// Parses include strings.
/// </summary>
public interface IIncludeStringParser
{

    /// <summary>
    /// Parses an include string and returns the IncludeOptions.
    /// </summary>
    /// <param name="includeString">The string to parse.</param>
    /// <returns>The include options.</returns>
    IncludeOptions Parse(string? includeString);

}