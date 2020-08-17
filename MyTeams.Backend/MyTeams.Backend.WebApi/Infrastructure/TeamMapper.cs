using MyTeams.Backend.Core.Model;
using MyTeams.Backend.WebApi.DataTransferObjects;
using System;

namespace MyTeams.Backend.WebApi.Infrastructure
{
  public class TeamMapper
  {
    public static TeamDto MapToDto(Team team)
      => new TeamDto() { Id = team.Id, DisplayName = team.DisplayName };
  }
}
