using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;

namespace MyTeams.Backend.Persistence.Repositories
{
  public class TeamRepository : BaseRepository<Team>, ITeamRepository
  {
    public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
  }
}
