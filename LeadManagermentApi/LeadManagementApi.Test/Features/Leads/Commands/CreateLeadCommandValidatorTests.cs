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

}