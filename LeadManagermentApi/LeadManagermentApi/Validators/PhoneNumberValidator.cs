using FluentValidation;
using System.Text.RegularExpressions;

namespace LeadManagermentApi.Validators;

/// <summary>
/// Contains functions to validate a phone number.
/// </summary>
public static class PhoneNumberValidator
{
    /// <summary>
    /// Regular expression for a phone number.
    /// </summary>
    private static readonly Regex PhoneNumberRegex = new Regex(@"^\(d{3}\) d{3}-d{4}$");

    /// <summary>
    /// Defines a rule that phone numbers must follow a format.
    /// </summary>
    /// <typeparam name="T">The type of object being validated.</typeparam>
    /// <param name="ruleBuilder">The rulebuilder.</param>
    /// <returns>A rulebuilder with the phone number rule.</returns>
    public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Matches(PhoneNumberRegex);
    }
}
