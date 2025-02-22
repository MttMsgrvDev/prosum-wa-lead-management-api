namespace LeadManagermentApi.Features.Contact.DTOs;

/// <summary>
/// Represents a contact.
/// </summary>
/// <param name="Id">Uniquely identifies the contact.</param>
/// <param name="Email">The email address of the contact.</param>
/// <param name="FirstName">The first name of the contact.</param>
/// <param name="LastName">The last name of the contact.</param>
/// <param name="PhoneNumber">The phone number of the contact.</param>
/// <param name="ZipCode">The zip code of the contact.</param>
/// <param name="PermissionToContact">Whether or not the contact has given permission to be contacted.</param>
public record ContactDto(
    Guid Id,
    string? Email,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string ZipCode,
    bool PermissionToContact);