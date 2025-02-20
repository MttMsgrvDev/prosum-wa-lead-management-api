using LeadManagermentApi.Features.Leads.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Leads.Commands.Create;

/// <summary>
/// A command to create a new lead.
/// </summary>
/// <param name="Source">The source of the lead.</param>
/// <param name="Subject">The subject line for the lead.</param>
/// <param name="Message">The message sent along with the lead.</param>
/// <param name="Email">The contact's email address.</param>
/// <param name="FirstName">The contact's first name.</param>
/// <param name="LastName">The contact's last name.</param>
/// <param name="PhoneNumber">The contact's phone number.</param>
/// <param name="ZipCode">The contact's zip code.</param>
/// <param name="PermissionToContact">Whether or not the contact gives permission to be contacted.</param>
public record CreateLeadCommand(
    string? Source,
    string? Subject,
    string? Message,
    string? Email,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string ZipCode,
    bool PermissionToContact
) : IRequest<LeadDto>;