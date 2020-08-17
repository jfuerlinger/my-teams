using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using MyTeams.Backend.WebApi.DataTransferObjects;
using MyTeams.Backend.WebApi.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeams.Backend.WebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MessagesController : ControllerBase
  {
    private readonly ILogger<MessagesController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public MessagesController(ILogger<MessagesController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet()]
    public async Task<ActionResult<MessageDto[]>> GetMessagesByChannelIdAsync(DateTime newerThan)
      => (await _unitOfWork.MessageRepository
            .GetMessagesNewerThan(newerThan))
            .Select(message => MessageMapper.MapToDto(message))
            .ToArray();
  }
}
