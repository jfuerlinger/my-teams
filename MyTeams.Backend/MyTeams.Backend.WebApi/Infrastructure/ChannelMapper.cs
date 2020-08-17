using MyTeams.Backend.Core.Model;
using MyTeams.Backend.WebApi.DataTransferObjects;

namespace MyTeams.Backend.WebApi.Infrastructure
{
  public class ChannelMapper
  {
    public static ChannelDto MapToDto(Channel channel)
      => new ChannelDto() { Id = channel.Id, DisplayName = channel.DisplayName, TeamId = channel.TeamId };
  }
}
