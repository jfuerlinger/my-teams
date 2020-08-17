using System;
using System.Threading.Tasks;

namespace MyTeams.Backend.Core.Contracts
{
  public interface IUnitOfWork : IDisposable
  {
    ITeamRepository TeamRepository { get; }
    IChannelRepository ChannelRepository { get; }
    IUserRepository UserRepository { get; }
    IMessageRepository MessageRepository { get; }

    Task<int> SaveChangesAsync();

    Task DeleteDatabaseAsync();
    Task MigrateDatabaseAsync();
  }
}
