using System;

namespace LeadManagermentApi.Data.Models.Entity;

/// <summary>
/// Represents a data entity record.
/// </summary>
public interface IEntity
{

    /// <summary>
    /// Globally unique identifier for the data entity.
    /// </summary>
    public Guid Id { get; set; }

}