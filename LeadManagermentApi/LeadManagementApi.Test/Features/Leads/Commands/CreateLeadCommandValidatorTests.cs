using FluentAssertions;
using LeadManagermentApi.Features.Leads.Commands.Create;

namespace LeadManagementApi.Test.Features.Leads.Commands;

public class CreateLeadCommandValidatorTests
{
    private readonly CreateLeadCommandValidator _validator;

    public CreateLeadCommandValidatorTests()
    {
        _validator = new CreateLeadCommandValidator();
    }

    [Fact]
    public void ValidCommand_Validate_Valid()
    {
        var command = new CreateLeadCommand("Test", "Test subject", "Testing", "matt@musgrove.io", "Matt", "Musgrove", "(805) 990-9141", "91306", true);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void InvalidEmail_Validate_Invalid()
    {
        var source = "Test Source";
        var subject = "Test Subject";
        var message = "Test Message";
        var email = "Hello !!!!";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        var command = new CreateLeadCommand(source, subject, message, email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Count.Should().Be(1);

        var error = result.Errors[0];

        error.PropertyName.Should().Be("Email");
    }

    [Fact]
    public void InvalidFirstName_Validate_Invalid()
    {
        var source = "Test Source";
        var subject = "Test Subject";
        var message = "Test Message";
        var email = "matt@musgrove.io";
        var firstName = "   ";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        var command = new CreateLeadCommand(source, subject, message, email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Count.Should().Be(1);

        var error = result.Errors[0];

        error.PropertyName.Should().Be("FirstName");
    }

    [Fact]
    public void InvalidLastName_Validate_Invalid()
    {
        var source = "Test Source";
        var subject = "Test Subject";
        var message = "Test Message";
        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "\t";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        var command = new CreateLeadCommand(source, subject, message, email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Count.Should().Be(1);

        var error = result.Errors[0];

        error.PropertyName.Should().Be("LastName");
    }

    [Fact]
    public void InvalidPhoneNumber_Validate_Invalid()
    {
        var source = "Test Source";
        var subject = "Test Subject";
        var message = "Test Message";
        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "1234";
        var zipCode = "91306";
        var permissionToContact = true;

        var command = new CreateLeadCommand(source, subject, message, email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Count.Should().Be(1);

        var error = result.Errors[0];

        error.PropertyName.Should().Be("PhoneNumber");
    }

    [Fact]
    public void InvalidZipCode_Validate_Invalid()
    {
        var source = "Test Source";
        var subject = "Test Subject";
        var message = "Test Message";
        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "913061234";
        var permissionToContact = true;

        var command = new CreateLeadCommand(source, subject, message, email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Count.Should().Be(1);

        var error = result.Errors[0];

        error.PropertyName.Should().Be("ZipCode");
    }
}