using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;

namespace MyTeams.Backend.Persistence.Repositories
{
  public class MessageRepository : BaseRepository<Message>, IMessageRepository
  {
    public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
  }
}
