using MyTeams.Backend.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeams.Backend.Core.Contracts
{
  public interface IMessageRepository : IBaseRepository<Message>
  {
    Task<IEnumerable<Message>> GetMessagesByChannelIdAndNewerThan(int channelId, DateTime newerThan);
    Task<IEnumerable<Message>> GetMessagesNewerThan(DateTime newerThan);
  }
}
