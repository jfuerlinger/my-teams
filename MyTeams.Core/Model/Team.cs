using System.Collections.Generic;
using System.Linq;

namespace MyTeams.Core.Model
{
  public class Team : EntityObject
  {
    public string DisplayName { get; private set; }

    public List<Channel> Channels { get; private set; }

    public Team(string displayName, string[] channels)
    {
      DisplayName = displayName;

      Channels = new List<Channel>();
      Channels.AddRange(channels.Select(displayName => new Channel(displayName, this)));
    }
  }
}
