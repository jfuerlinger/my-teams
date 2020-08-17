using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Persistence.Repositories;
using System.Threading.Tasks;

namespace MyTeams.Backend.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork()
    {
      _dbContext = new ApplicationDbContext();
      TeamRepository = new TeamRepository(_dbContext);
      ChannelRepository = new ChannelRepository(_dbContext);
      UserRepository = new UserRepository(_dbContext);
      MessageRepository = new MessageRepository(_dbContext);
    }

    public ITeamRepository TeamRepository { get; }

    public IChannelRepository ChannelRepository { get; }

    public IUserRepository UserRepository { get; }

    public IMessageRepository MessageRepository { get; }

    public async Task<int> SaveChangesAsync()
      => await _dbContext.SaveChangesAsync();


    public async Task DeleteDatabaseAsync()
      => await _dbContext.Database.EnsureDeletedAsync();

    public async Task MigrateDatabaseAsync()
      => await _dbContext.Database.EnsureCreatedAsync();

    public void Dispose()
      => _dbContext.Dispose();
  }
}
