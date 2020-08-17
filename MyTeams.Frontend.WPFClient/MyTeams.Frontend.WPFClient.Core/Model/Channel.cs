using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyTeams.Core.Model
{
  public class Channel : EntityObject
  {
    public string DisplayName { get; private set; }
    public List<Message> Messages { get; private set; }

    public Team Team { get; private set; }

    public Channel(string displayName, Team team)
    {
      DisplayName = displayName;
      Team = team;
      Messages = new List<Message>();
    }
  }
}
