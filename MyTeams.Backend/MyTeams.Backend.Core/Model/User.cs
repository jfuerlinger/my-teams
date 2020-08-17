using System.ComponentModel.DataAnnotations;

namespace MyTeams.Backend.Core.Model
{
  public class User : EntityObject
  {
    [Required]
    public string Firstname { get; set; }

    [Required]
    public string Lastname { get; set; }
    
    public string Fullname => $"{Firstname} {Lastname}";
    
    
    public string AvatarUrl => $"https://robohash.org/{Id}.png?&size=150x150";
  }
}
