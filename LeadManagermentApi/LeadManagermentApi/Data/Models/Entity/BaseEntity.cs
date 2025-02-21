namespace LeadManagermentApi.Data.Models.Entity;

/// <summary>
/// Represents a data entity record.
/// </summary>
public class BaseEntity : IEntity
{
    /// <summary>
    /// Globally unique identifier for the entity record.
    /// </summary>
    public Guid Id { get; set; }
}