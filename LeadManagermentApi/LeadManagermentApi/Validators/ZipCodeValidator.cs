using FluentValidation;
using System.Text.RegularExpressions;

namespace LeadManagermentApi.Validators;

/// <summary>
/// Contains functions to validate a zip code.
/// </summary>
public static class ZipCodeValidator
{

    /// <summary>
    /// Regex pattern to validate a zip code.
    /// </summary>
    private static readonly Regex ZipCodeRegex = new Regex("^[0-9]{5}(?:-[0-9]{4})?$");

    /// <summary>
    /// Defines a rule that phone numbers must follow a format.
    /// </summary>
    /// <typeparam name="T">The type of object being validated.</typeparam>
    /// <param name="ruleBuilder">The rulebuilder.</param>
    /// <returns>A rulebuilder with the phone number rule.</returns>
    public static IRuleBuilderOptions<T, string> ZipCode<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Matches(ZipCodeRegex);
    }

}