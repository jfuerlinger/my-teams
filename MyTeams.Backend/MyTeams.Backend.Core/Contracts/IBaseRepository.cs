using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeams.Backend.Core.Contracts
{
  public interface IBaseRepository<T> where T : class
  {
    Task<T[]> GetAllAsync();
    Task<T> GetByIdAsync(int id);

    Task AddAsync(T item);
    Task AddRangeAsync(IEnumerable<T> items);

    Task RemoveAsync(T item);
  }
}
