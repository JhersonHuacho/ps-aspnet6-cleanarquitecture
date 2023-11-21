using GloboTicket.TicketManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.IntegrationTests.Base;
public class Utilities
{
    public static void InitializeDbForTests(GloboTicketDbContext context)
    {
        var concertGuid = Guid.Parse("{d5b8f8f4-ccbd-4f4f-9a4b-3e5d8e3d0c9c}");
        var musicalGuid = Guid.Parse("{d5b8f8f4-ccbd-4f4f-9a4b-3e5d8e3d0c9d}");
        var playGuid = Guid.Parse("{d5b8f8f4-ccbd-4f4f-9a4b-3e5d8e3d0c9e}");
        var conferenceGuid = Guid.Parse("{d5b8f8f4-ccbd-4f4f-9a4b-3e5d8e3d0c9f}");

        context.Categories.AddRange(
            new Domain.Entities.Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            },
            new Domain.Entities.Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            },
            new Domain.Entities.Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            },
            new Domain.Entities.Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            }                                                    
        );

        context.SaveChanges();
    }
}
