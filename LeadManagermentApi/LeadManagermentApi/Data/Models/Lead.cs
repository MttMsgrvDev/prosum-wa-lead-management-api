using LeadManagermentApi.Data.Models.Entity;

namespace LeadManagermentApi.Data.Models;

/// <summary>
/// Respresents a Lead entity record.
/// </summary>
public class Lead : BaseEntity
{

    /// <summary>
    /// The source of the lead.
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// The subject line from the lead.
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// The lead's message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Uniquely identifies the contact for this lead.
    /// </summary>
    public Guid ContactId { get; set; }

    /// <summary>
    /// The contact for the lead.
    /// </summary>
    public Contact Contact { get; set; }

    /// <summary>
    /// The date and time the lead was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

}
