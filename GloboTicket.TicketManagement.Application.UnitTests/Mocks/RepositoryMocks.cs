using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.UnitTests.Mocks;
public class RepositoryMocks
{
    public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
    {
        var concertGuid = Guid.Parse("{3fa85f64-5717-4562-b3fc-2c963f66afa6}");
        var musicalGuid = Guid.Parse("{0f5b0935-03c5-41b7-8a92-2bcdc5c5f519}");
        var playGuid = Guid.Parse("{b3a8c5d5-ff7a-4bfa-8a84-405e1c0000f1}");
        var conferenceGuid = Guid.Parse("{b3a8c5d5-ff7a-4bfa-8a84-405e1c0000f2}");

        var categories = new List<Category>
        {
            new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            },
            new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            },
            new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            },
            new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            }
        };

        var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
        mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

        mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>()))
            .ReturnsAsync(
                (Category category) => 
                {
                    categories.Add(category);
                    return category;
                });

        return mockCategoryRepository;
    }
}
