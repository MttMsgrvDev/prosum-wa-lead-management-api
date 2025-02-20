using FluentValidation;
using LeadManagermentApi.Validators;

namespace LeadManagermentApi.Features.Contact.Commands.Create;

/// <summary>
/// Validator class for the CreateContactCommand.
/// </summary>
public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{

    public CreateContactCommandValidator()
    {
        When(c => !string.IsNullOrWhiteSpace(c.Email),
            () => RuleFor(c => c.Email).EmailAddress().WithMessage("Invalid email address."));

        RuleFor(c => c.FirstName).NotNull().NotEmpty().WithMessage("First name must not be null or empty.");

        RuleFor(c => c.LastName).NotNull().NotEmpty().WithMessage("Last name must not be null or empty.");

        RuleFor(c => c.PhoneNumber).NotNull().NotEmpty().PhoneNumber().WithMessage(@"Phone number must be in a valid phone number format.");

        RuleFor(c => c.ZipCode).NotNull().NotEmpty().ZipCode().WithMessage(@"Zip code must match the format ""#####"" or ""#####-####""");
    }

}