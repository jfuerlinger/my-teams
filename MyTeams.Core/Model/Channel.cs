using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyTeams.Core.Model
{
  public class Channel 
  {
    public string DisplayName { get; private set; }
    public List<string> Messages { get; private set; }

    public Team Team { get; private set; }


    public Channel(string displayName, Team team)
    {
      DisplayName = displayName;
      Team = team;
      Messages = new List<string>();
    }
  }
}
