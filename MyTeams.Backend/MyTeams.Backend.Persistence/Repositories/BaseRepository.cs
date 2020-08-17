using Microsoft.EntityFrameworkCore;
using MyTeams.Backend.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeams.Backend.Persistence.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    private readonly ApplicationDbContext _dbContext;

    protected ApplicationDbContext DbContext => _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<T[]> GetAllAsync()
      => await _dbContext.Set<T>()
          .ToArrayAsync();

    public async Task<T> GetByIdAsync(int id)
      => await _dbContext.Set<T>()
          .FindAsync(id);

    public async Task AddAsync(T item)
      => await _dbContext.Set<T>()
          .AddAsync(item);

    public async Task AddRangeAsync(IEnumerable<T> items)
      => await _dbContext.Set<T>()
          .AddRangeAsync(items);

    public Task RemoveAsync(T item)
    {
      _dbContext.Set<T>()
        .Remove(item);

      return Task.CompletedTask;
    }
  }
}
