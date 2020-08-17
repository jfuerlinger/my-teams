using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTeams.Backend.Core.Model
{
  public class Channel : EntityObject
  {
    [Required]
    [MinLength(5)]
    public string DisplayName { get; set; }

    [Required]
    public Team Team { get; set; }
    public int TeamId { get; set; }

    public ICollection<Message> Messages { get; set; } = new List<Message>();
  }
}
