using MyTeams.Core.Model;
using System.Collections.Generic;

namespace MyTeams.Core.Contracts
{
  public interface ITeamsService
  {
    IEnumerable<Team> Teams { get; }
  }
}
