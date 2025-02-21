using LeadManagermentApi.Data.Models.Entity;

namespace LeadManagermentApi.Data.Models;

/// <summary>
/// Represents a contact record.
/// </summary>
public class Contact : BaseEntity
{
    /// <summary>
    /// The contact's email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The contact's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The contact's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The contact's phone number.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// The contact's zip code.
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// Whether or not the contact gives permission to contact.
    /// </summary>
    public bool PermissionToContact { get; set; }

    /// <summary>
    /// The leads related to the contact.
    /// </summary>
    public IList<Lead> Leads { get; set; }
}