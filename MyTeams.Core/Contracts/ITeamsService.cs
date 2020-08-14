using MyTeams.Core.Model;
using System.Collections.Generic;

namespace MyTeams.Core.Contracts
{
  public delegate void MessageReceivedHandler(Message message);

  public interface ITeamsService
  {
    User CurrentUser { get; }
    IEnumerable<Team> GetTeams();
    event MessageReceivedHandler MessageReceived;
  }
}
