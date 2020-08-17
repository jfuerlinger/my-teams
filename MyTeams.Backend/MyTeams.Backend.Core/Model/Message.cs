using System;
using System.ComponentModel.DataAnnotations;

namespace MyTeams.Backend.Core.Model
{
  public class Message : EntityObject
  {
    public DateTime Sent { get; set; }

    [Required]
    public Channel Channel { get; set; }
    public int ChannelId { get; set; }

    [Required]
    public User From { get; set; }
    public int FromId { get; set; }

    [Required]
    public string Text { get; set; }
  }
}
