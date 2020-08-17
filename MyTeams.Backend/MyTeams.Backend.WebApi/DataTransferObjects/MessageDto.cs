using System;

namespace MyTeams.Backend.WebApi.DataTransferObjects
{
  public class MessageDto
  {
    public int Id { get; set; }
    public int ChannelId { get; set; }
    public int FromId { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public DateTime Sent { get; set; }
    public bool IsImageMessage { get; set; }
  }
}
