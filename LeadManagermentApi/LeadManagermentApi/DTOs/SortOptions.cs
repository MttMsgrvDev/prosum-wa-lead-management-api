namespace LeadManagermentApi.DTOs;

/// <summary>
/// Sort options for a query
/// </summary>
/// <param name="Fields">Describes the fields to sort by and in which direction to sort them.</param>
public record SortOptions(IEnumerable<KeyValuePair<string, SortDirection>>? Fields = null);