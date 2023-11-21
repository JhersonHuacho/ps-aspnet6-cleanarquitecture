using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories;
public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly GloboTicketDbContext _globoTicketDbContext;

    public BaseRepository(GloboTicketDbContext dbContext)
    {
        _globoTicketDbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return await _globoTicketDbContext.Set<T>().FindAsync(id);
        
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _globoTicketDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _globoTicketDbContext.Set<T>().AddAsync(entity);
        await _globoTicketDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _globoTicketDbContext.Entry(entity).State = EntityState.Modified;
        await _globoTicketDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _globoTicketDbContext.Set<T>().Remove(entity);
        await _globoTicketDbContext.SaveChangesAsync();
    }
}
