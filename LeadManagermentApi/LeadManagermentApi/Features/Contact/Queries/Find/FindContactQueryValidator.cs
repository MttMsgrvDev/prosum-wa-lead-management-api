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
        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
            RuleFor(c => c.Email).EmailAddress().WithMessage("Invalid email address."));

        When(c => string.IsNullOrEmpty(c.Email), () =>
        {
            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty().WithMessage("Either phone number and last name or email must be populated. Both cannot be empty.");
            RuleFor(c => c.LastName).NotNull().NotEmpty().WithMessage("Either phone number and last name or email must be populated. Both cannot be empty.");
        });
    }

}