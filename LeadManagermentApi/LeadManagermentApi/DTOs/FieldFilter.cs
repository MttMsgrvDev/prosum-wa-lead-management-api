namespace LeadManagermentApi.DTOs;

/// <summary>
/// Represents a field filter.
/// </summary>
/// <param name="Field">The field to filter.</param>
/// <param name="Operator">The filtering operator.</param>
/// <param name="Value">The filtering value.</param>
public record FieldFilter(
    string Field,
    FieldFilterOperator Operator,
    object Value);