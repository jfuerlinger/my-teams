using Microsoft.EntityFrameworkCore;
using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeams.Backend.Persistence.Repositories
{
  public class ChannelRepository : BaseRepository<Channel>, IChannelRepository
  {
    public ChannelRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Channel[]> GetByTeamIdAsync(int teamId)
      => await DbContext.Channels
          .Where(channel => channel.TeamId == teamId)
          .OrderBy(channel => channel.DisplayName)
          .ToArrayAsync();
    
  }
}
