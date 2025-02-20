using FluentValidation;
using LeadManagermentApi.Validators;

namespace LeadManagermentApi.Features.Contact.Queries.Find;

/// <summary>
/// Validator class for FindContactQuery.
/// </summary>
public class FindContactQueryValidator : AbstractValidator<FindContactQuery>
{

    public FindContactQueryValidator()
    {
        When(c => !string.IsNullOrWhiteSpace(c.PhoneNumber), () =>
            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty().PhoneNumber().WithMessage(@"Phone number must be in a valid phone number format."));

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
            RuleFor(c => c.Email).EmailAddress().WithMessage("Invalid email address."));

        When(c => string.IsNullOrWhiteSpace(c.PhoneNumber), () =>
            RuleFor(c => c.Email).NotNull().NotEmpty());

        When(c => string.IsNullOrWhiteSpace(c.Email), () =>
            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty());
    }

}