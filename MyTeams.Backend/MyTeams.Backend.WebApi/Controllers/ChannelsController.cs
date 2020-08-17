using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using MyTeams.Backend.WebApi.DataTransferObjects;
using MyTeams.Backend.WebApi.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeams.Backend.WebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ChannelsController : ControllerBase
  {
    private readonly ILogger<ChannelsController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ChannelsController(ILogger<ChannelsController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<Channel[]> GetAsync()
      => await _unitOfWork.ChannelRepository.GetAllAsync();

    [HttpGet("{channelId}/messages")]
    public async Task<ActionResult<MessageDto[]>> GetMessagesByChannelIdAsync(
      int channelId, 
      [Required] DateTime newerThan)

      => (await _unitOfWork.MessageRepository
            .GetMessagesByChannelIdAndNewerThan(channelId, newerThan))
            .Select(message => MessageMapper.MapToDto(message))
            .ToArray();
  }
}
