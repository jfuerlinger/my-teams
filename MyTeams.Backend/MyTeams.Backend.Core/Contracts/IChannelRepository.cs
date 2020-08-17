using MyTeams.Backend.Core.Model;
using System.Threading.Tasks;

namespace MyTeams.Backend.Core.Contracts
{
  public interface IChannelRepository : IBaseRepository<Channel>
  {
    Task<Channel[]> GetByTeamIdAsync(int teamId);
  }
}
