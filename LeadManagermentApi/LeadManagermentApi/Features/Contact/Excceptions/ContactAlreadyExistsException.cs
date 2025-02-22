using LeadManagermentApi.Exceptions.Http;

namespace LeadManagermentApi.Features.Contact.Excceptions;

/// <summary>
/// The contact already exists exception.
/// </summary>
public class ContactAlreadyExistsException : HttpException
{
    /// <summary>
    /// Creates a new instance of ContactAlreadyExistsException.
    /// </summary>
    public ContactAlreadyExistsException() : base(StatusCodes.Status400BadRequest, "Contact Already Exists", "A contact with the same email address already exists.")
    {

    }
}