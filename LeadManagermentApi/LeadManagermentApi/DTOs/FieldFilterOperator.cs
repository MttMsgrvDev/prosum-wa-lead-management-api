namespace LeadManagermentApi.DTOs;

/// <summary>
/// Operators that can be used with a field filter
/// </summary>
public enum FieldFilterOperator
{
    /// <summary>
    /// Represents the equals operator.
    /// </summary>
    Equal,

    /// <summary>
    /// Represents the greater than operator.
    /// </summary>
    GreaterThan,

    /// <summary>
    /// Represents the greater than or equal to operator.
    /// </summary>
    GreaterThanOrEqual,

    /// <summary>
    /// Represents the less than operator.
    /// </summary>
    LessThan,

    /// <summary>
    /// Represents the less than or equal to operator.
    /// </summary>
    LessThanOrEqual
}