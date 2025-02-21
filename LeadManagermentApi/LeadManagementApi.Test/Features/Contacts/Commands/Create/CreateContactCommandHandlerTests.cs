using AutoMapper;
using FluentAssertions;
using LeadManagermentApi.Data.Models;
using LeadManagermentApi.Features.Contact.Commands.Create;
using LeadManagermentApi.Features.Contact.Excceptions;
using LeadManagermentApi.Features.Contact.Profiles;
using LeadManagermentApi.Repositories;
using Moq;
using System.Linq.Expressions;

namespace LeadManagementApi.Test.Features.Contacts.Commands.Create;

public class CreateContactCommandHandlerTests
{

    private readonly Mock<IReadWriteRepository<Contact>> _contactRepo;

    private readonly CreateContactCommandHandler _handler;

    private readonly IMapper _mapper;

    public CreateContactCommandHandlerTests()
    {
        var mappingConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ContactProfile());
        });
        _mapper = mappingConfig.CreateMapper();

        _contactRepo = new Mock<IReadWriteRepository<Contact>>();
        _handler = new CreateContactCommandHandler(_contactRepo.Object, _mapper);
    }

    [Fact]
    public async Task BrandNewContact_Handle_CreatesNewContact()
    {
        var newGuid = new Guid("dff522a5-507e-4983-a237-d09435cc35f5");

        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        _contactRepo.Setup(cr => cr.GetManyAsync(
            It.IsAny<Expression<Func<Contact, bool>>>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        _contactRepo.Setup(cr => cr.CreateAsync(
            It.Is<Contact>(c => string.Equals(c.Email, email, StringComparison.OrdinalIgnoreCase)), 
            It.IsAny<CancellationToken>())).ReturnsAsync(new Contact
        {
            Id = newGuid,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            ZipCode = zipCode,
            PermissionToContact = permissionToContact
        });

        var command = new CreateContactCommand(email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be(newGuid);
        result.Email.Should().Be(email);
    }

    [Fact]
    public async Task ContactAlreadyExists_Handle_ThrowsAlreadyExistsException()
    {
        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        _contactRepo.Setup(cr => cr.GetManyAsync(
            It.IsAny<Expression<Func<Contact, bool>>>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync([ new Contact {
                Id = Guid.NewGuid(),
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                ZipCode = zipCode,
                PermissionToContact = permissionToContact
            }]);

        var command = new CreateContactCommand(email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        await Assert.ThrowsAsync<ContactAlreadyExistsException>(() => _handler.Handle(command, CancellationToken.None));
    }
}