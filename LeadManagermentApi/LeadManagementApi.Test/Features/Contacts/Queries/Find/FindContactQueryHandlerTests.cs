using AutoMapper;
using FluentAssertions;
using LeadManagermentApi.Data.Models;
using LeadManagermentApi.DTOs;
using LeadManagermentApi.Features.Contact.Profiles;
using LeadManagermentApi.Features.Contact.Queries.Find;
using LeadManagermentApi.Repositories;
using Moq;
using System.Linq.Expressions;

namespace LeadManagementApi.Test.Features.Contacts.Queries.Find;

public class FindContactQueryHandlerTests
{

    private readonly Mock<IReadRepository<Contact>> _contactRepo;

    private readonly FindContactQueryHandler _handler;

    private readonly IMapper _mapper;

    public FindContactQueryHandlerTests()
    {
        var mappingConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ContactProfile());
        });
        _mapper = mappingConfig.CreateMapper();

        _contactRepo = new Mock<IReadRepository<Contact>>();

        _handler = new FindContactQueryHandler(_contactRepo.Object, _mapper);
    }

    [Fact]
    public async Task EmailExists_Handle_Found()
    {
        var newGuid = new Guid("dff522a5-507e-4983-a237-d09435cc35f5");

        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        _contactRepo.Setup(cr => cr.GetManyAsync(
            It.IsAny<FilterOptions?>(),
            It.IsAny<IncludeOptions?>(),
            It.IsAny<SortOptions?>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync([ new Contact
                {
                    Id = newGuid,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    ZipCode = zipCode,
                    PermissionToContact = permissionToContact
                }]);

        var query = new FindContactQuery(email, phoneNumber, lastName);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();

        result.Id.Should().Be(newGuid);
        result.Email.Should().Be(email);
    }

    [Fact]
    public async Task RecordsDoNotExist_Handle_NotFound()
    {
        var email = "matt@musgrove.io";
        var phoneNumber = "(805) 990-9141";
        var lastName = "Musgrove";

        _contactRepo.Setup(cr => cr.GetManyAsync(
            It.IsAny<FilterOptions?>(),
            It.IsAny<IncludeOptions?>(),
            It.IsAny<SortOptions?>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        var query = new FindContactQuery(email, phoneNumber, lastName);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().BeNull();
    }
}
