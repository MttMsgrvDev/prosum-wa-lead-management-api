namespace LeadManagermentApi.Features.Leads.ViewModel;

/// <summary>
/// Represents a lead in the lead manmagement system.
/// </summary>
/// <param name="Id">Uniquely identifies the lead.</param>
/// <param name="Source">The source of the lead.</param>
/// <param name="Subject">The subject line for the lead.</param>
/// <param name="Message">The message from the lead.</param>
/// <param name="Email">The lead's email address.</param>
/// <param name="FirstName">The first name of the lead.</param>
/// <param name="LastName">The last name of the lead.</param>
/// <param name="PhoneNumber">The lead's phone number.</param>
/// <param name="ZipCode">The lead's zip code.</param>
/// <param name="PermissionToContact">Whether or not the lead has given permission to contact them.</param>
/// <param name="CreatedDate">The date the lead was created.</param>
public record LeadViewModel(
    Guid Id,
    string? Source,
    string? Subject,
    string? Message,
    string? Email,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string ZipCode,
    bool PermissionToContact,
    DateTime CreatedDate);