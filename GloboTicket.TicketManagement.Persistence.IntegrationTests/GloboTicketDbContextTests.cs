using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests;
public class GloboTicketDbContextTests
{
    private readonly GloboTicketDbContext _globoTicketDbContext;
    private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
    private readonly string _loggedInUserId;

    public GloboTicketDbContextTests()
    {
        _loggedInUserId = Guid.NewGuid().ToString();
        _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
        _loggedInUserServiceMock.Setup(x => x.UserId).Returns(_loggedInUserId);

        var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
    }

    [Fact]
    public async Task Save_SetCreatedByProperty()
    {
        var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test Event" };

        _globoTicketDbContext.Events.Add(ev);
        await _globoTicketDbContext.SaveChangesAsync();

        ev.CreatedBy.ShouldBe(_loggedInUserId);
    }

}
