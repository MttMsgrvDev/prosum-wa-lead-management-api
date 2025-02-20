using LeadManagermentApi.Features.Contact.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Contact.Commands.Create;

/// <summary>
/// Command to create a new contact.
/// </summary>
/// <param name="Email">The contact's email address.</param>
/// <param name="FirstName">The contact's first name.</param>
/// <param name="LastName">The contact's last name.</param>
/// <param name="PhoneNumber">The contact's phone number.</param>
/// <param name="ZipCode">The contact's zip code.</param>
/// <param name="PermissionToContact">Whether or not the contact gives permission to be contacted.</param>
public record CreateContactCommand(
    string? Email,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string ZipCode,
    bool PermissionToContact) : IRequest<ContactDto>;