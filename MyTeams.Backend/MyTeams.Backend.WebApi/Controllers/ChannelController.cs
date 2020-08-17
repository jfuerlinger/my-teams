using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using System.Threading.Tasks;

namespace MyTeams.Backend.WebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ChannelController : ControllerBase
  {
    private readonly ILogger<ChannelController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ChannelController(ILogger<ChannelController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<Channel[]> GetAsync()
      => await _unitOfWork.ChannelRepository.GetAllAsync();

  }
}
