using MyTeams.Backend.Core.Model;
using MyTeams.Backend.WebApi.DataTransferObjects;
using System;

namespace MyTeams.Backend.WebApi.Infrastructure
{
  public class MessageMapper
  {
    public static MessageDto MapToDto(Message message)
      => message switch
      {
        ImageMessage imageMessage => new MessageDto()
        {
          Id = imageMessage.Id,
          IsImageMessage = true,
          ChannelId = imageMessage.ChannelId,
          FromId = imageMessage.FromId,
          ImageUrl = imageMessage.ImageUrl,
          Sent = imageMessage.Sent,
          Text = imageMessage.Text

        },
        Message simpleMessage => new MessageDto()
        {
          Id = simpleMessage.Id,
          IsImageMessage = false,
          ChannelId = simpleMessage.ChannelId,
          FromId = simpleMessage.FromId,
          Sent = simpleMessage.Sent,
          Text = simpleMessage.Text
        },
        _ => throw new Exception($"Unknown Message type '{message.GetType()}'!")
      };
  }
}
