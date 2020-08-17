using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;

namespace MyTeams.Backend.Persistence.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
  }
}
