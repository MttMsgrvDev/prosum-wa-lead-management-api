namespace LeadManagermentApi.Features.Leads.DTOs;

/// <summary>
/// Represents a lead.
/// </summary>
/// <param name="Id">Uniquely identifies the lead.</param>
/// <param name="Source">The source of the lead.</param>
/// <param name="Subject">The subject line for the lead.</param>
/// <param name="Message">The message from the lead contact.</param>
/// <param name="Contact">The contact for the lead.</param>
/// <param name="CreatedDate">The date the lead was created.</param>
public record LeadDto(
    Guid Id,
    string? Source,
    string? Subject,
    string? Message,
    ContactDto Contact,
    DateTime CreatedDate);