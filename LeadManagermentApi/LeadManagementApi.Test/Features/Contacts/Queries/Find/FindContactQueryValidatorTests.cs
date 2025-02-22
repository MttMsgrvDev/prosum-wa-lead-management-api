using FluentAssertions;
using LeadManagermentApi.Features.Contact.Queries.Find;

namespace LeadManagementApi.Test.Features.Contacts.Queries.Find;

public class FindContactQueryValidatorTests
{

    private readonly FindContactQueryValidator _validator;

    public FindContactQueryValidatorTests()
    {
        _validator = new FindContactQueryValidator();
    }

    [Fact]
    public void BothEmailAndPhone_Validate_IsValid()
    {
        var email = "matt@musgrove.io";
        var phoneNumber = "(805) 990-9141";
        var lastName = "Musgrove";

        var query = new FindContactQuery(email, phoneNumber, lastName);

        var result = _validator.Validate(query);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void OnlyPhoneAndLastName_Validate_IsValid()
    {
        string email = null;
        var phoneNumber = "(805) 990-9141";
        var lastName = "Musgrove";

        var query = new FindContactQuery(email, phoneNumber, lastName);

        var result = _validator.Validate(query);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void OnlyPhone_Validate_Invalid()
    {
        string email = null;
        var phoneNumber = "(805) 990-9141";
        string lastName = null;

        var query = new FindContactQuery(email, phoneNumber, lastName);

        var result = _validator.Validate(query);

        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void OnlyEmail_Validate_IsValid()
    {
        var email = "matt@musgrove.io";
        string phoneNumber = null;
        string lastName = null;

        var query = new FindContactQuery(email, phoneNumber, lastName);

        var result = _validator.Validate(query);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void NietherPhoneLastNameNorEmail_Validate_Invalid()
    {
        string email = null;
        string phoneNumber = null;
        string lastName = null;

        var query = new FindContactQuery(email, phoneNumber, lastName);

        var result = _validator.Validate(query);

        result.IsValid.Should().BeFalse();
    }
}