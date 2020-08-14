using System;

namespace MyTeams.Core.Model
{
  public class Message : EntityObject
  {
    public DateTime Sent { get; set; }
    public Channel Channel { get; set; }
    public User From { get; set; }
    public string Text { get; set; }
  }
}
