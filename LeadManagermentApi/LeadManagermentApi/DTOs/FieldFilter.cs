namespace LeadManagermentApi.DTOs;

/// <summary>
/// Represents a field filter.
/// </summary>
/// <param name="field">The field to filter.</param>
/// <param name="oper">The filtering operator.</param>
/// <param name="value">The filtering value.</param>
public record FieldFilter(
    string Field,
    string Oper,
    object Value);