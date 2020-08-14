namespace MyTeams.Core.Model
{
  public class User : EntityObject
  {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Fullname => $"{Firstname} {Lastname}";
    public string AvatarUrl => $"https://robohash.org/{Id}.png?&size=150x150";
  }
}
