using MyTeams.Backend.Core.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTeams.Backend.Core.Model
{
  public class Team : EntityObject
  {
    [Required]
    [MinLength(5)]
    public string DisplayName { get; set; }

    public ICollection<Channel> Channels { get; set; } = new List<Channel>();
  }
}
