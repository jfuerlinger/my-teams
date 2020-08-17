using System.ComponentModel.DataAnnotations;

namespace MyTeams.Backend.Core.Model
{
  public class ImageMessage : Message
  {
    [Required]
    public string ImageUrl { get; set; }
  }
}
