using AutoMapper;
using FluentAssertions;
using LeadManagermentApi.Data.Models;
using LeadManagermentApi.Features.Contact.Commands.Create;
using LeadManagermentApi.Features.Contact.DTOs;
using LeadManagermentApi.Features.Contact.Profiles;
using LeadManagermentApi.Features.Contact.Queries.Find;
using LeadManagermentApi.Features.Leads.Commands.Create;
using LeadManagermentApi.Features.Leads.Profiles;
using LeadManagermentApi.Repositories;
using LeadManagermentApi.Services.Clock;
using MediatR;
using Moq;
using System.Threading.Tasks;

namespace LeadManagementApi.Test.Features.Leads.Commands.Create;

public class CreateLeadCommandHandlerTests
{
    private static readonly DateTime Now = new DateTime(2025, 1, 1, 0, 0, 0);

    private readonly Mock<IClockService> _clockService;

    private readonly Mock<IWriteRepository<Lead>> _leadRepository;

    private readonly CreateLeadCommandHandler _handler;

    private readonly IMapper _mapper;

    private readonly Mock<IMediator> _mediator;

    public CreateLeadCommandHandlerTests()
    {
        _clockService = new Mock<IClockService>();

        _leadRepository = new Mock<IWriteRepository<Lead>>();

        _mediator = new Mock<IMediator>();

        var mappingConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ContactProfile());
            cfg.AddProfile(new LeadProfile());
        });
        _mapper = mappingConfig.CreateMapper();

        _handler = new CreateLeadCommandHandler(
            _leadRepository.Object,
            _mediator.Object,
            _mapper,
            _clockService.Object);
    }

    [Fact]
    public async Task NewContactAndLead_Handle_CreatesNewLead()
    {
        var leadId = new Guid("b22ca876-484d-42f7-97f5-8da1e15855ce");
        var message = "This is a test!";
        var subject = "Testing";
        var source = "Test";
        var createdDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);

        var contactId = new Guid("1208c628-0ee0-4c83-b35a-024d476cad08");
        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        _mediator.Setup(m => m.Send(
            It.Is<FindContactQuery>(q => string.Equals(q.Email, email, StringComparison.OrdinalIgnoreCase)),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync((ContactDto?)null);

        _mediator.Setup(m => m.Send(
            It.Is<CreateContactCommand>(c => string.Equals(c.Email, email, StringComparison.OrdinalIgnoreCase)),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ContactDto(contactId, email, firstName, lastName, phoneNumber, zipCode, permissionToContact));

        _leadRepository.Setup(lr => lr.CreateAsync(
            It.Is<Lead>(l => l.ContactId == contactId),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Lead
            {
                Id = leadId,
                ContactId = contactId,
                Message = message,
                Subject = subject,
                Source = source,
                CreatedDate = createdDate
            });

        _clockService.Setup(cs => cs.UtcNow)
            .Returns(Now);

        var command = new CreateLeadCommand(source, subject, message, email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be(leadId);
        result.Contact.Should().NotBeNull();
        result.Contact.Id.Should().Be(contactId);
    }

    [Fact]
    public async Task ContactExists_CreateLead_CreatesNewLeadWithOldContact()
    {
        var leadId = new Guid("b22ca876-484d-42f7-97f5-8da1e15855ce");
        var message = "This is a test!";
        var subject = "Testing";
        var source = "Test";
        var createdDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);

        var contactId = new Guid("1208c628-0ee0-4c83-b35a-024d476cad08");
        var email = "matt@musgrove.io";
        var firstName = "Matt";
        var lastName = "Musgrove";
        var phoneNumber = "(805) 990-9141";
        var zipCode = "91306";
        var permissionToContact = true;

        _mediator.Setup(m => m.Send(
            It.Is<FindContactQuery>(q => string.Equals(q.Email, email, StringComparison.OrdinalIgnoreCase)),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ContactDto(contactId, email, firstName, lastName, phoneNumber, zipCode, permissionToContact));

        _leadRepository.Setup(lr => lr.CreateAsync(
            It.Is<Lead>(l => l.ContactId == contactId),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Lead
            {
                Id = leadId,
                ContactId = contactId,
                Message = message,
                Subject = subject,
                Source = source,
                CreatedDate = createdDate
            });

        _clockService.Setup(cs => cs.UtcNow)
            .Returns(Now);

        var command = new CreateLeadCommand(source, subject, message, email, firstName, lastName, phoneNumber, zipCode, permissionToContact);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be(leadId);
        result.Contact.Should().NotBeNull();
        result.Contact.Id.Should().Be(contactId);

        _mediator.Verify(m => m.Send(
            It.IsAny<CreateContactCommand>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }
}