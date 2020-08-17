using Microsoft.EntityFrameworkCore;
using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeams.Backend.Persistence.Repositories
{
  public class MessageRepository : BaseRepository<Message>, IMessageRepository
  {
    public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Message>> GetMessagesByChannelIdAndNewerThan(int channelId, DateTime newerThan)
      => await DbContext.Messages
          .Where(message => message.ChannelId == channelId && message.Sent >= newerThan)
          .OrderBy(message => message.Sent)
          .ToArrayAsync();

    public async Task<IEnumerable<Message>> GetMessagesNewerThan(DateTime newerThan)
      => await DbContext.Messages
          .Where(message => message.Sent >= newerThan)
          .OrderBy(message => message.Sent)
          .ToArrayAsync();
  }
}
