using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeams.Backend.WebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TeamsController : ControllerBase
  {
    private readonly ILogger<TeamsController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public TeamsController(ILogger<TeamsController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Team>> GetById(int id)
      => await _unitOfWork.TeamRepository
          .GetByIdAsync(id);

    [HttpGet]
    public async Task<ActionResult<Team[]>> Get()
      => (await _unitOfWork.TeamRepository
          .GetAllAsync())
          .OrderBy(team => team.DisplayName)
          .ToArray();

    [HttpGet("{id}/channels")]
    public async Task<ActionResult<Channel[]>> GetChannelsByTeamId(int id)
      => (await _unitOfWork.ChannelRepository
          .GetByTeamIdAsync(id))
          .OrderBy(channel => channel.DisplayName)
          .ToArray();

    [HttpPost]
    public async Task<ActionResult<Team>> Add(string displayName)
    {
      Team newTeam = new Team() { DisplayName = displayName };

      await _unitOfWork.TeamRepository.AddAsync(newTeam);
      await _unitOfWork.SaveChangesAsync();

      return CreatedAtAction(
        nameof(GetById),
        new
        {
          id = newTeam.Id
        },
        new
        {
          DisplayName = displayName
        });
    }
  }
}
