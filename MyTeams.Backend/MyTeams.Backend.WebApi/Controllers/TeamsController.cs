using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTeams.Backend.Core.Contracts;
using MyTeams.Backend.Core.Model;
using MyTeams.Backend.WebApi.DataTransferObjects;
using MyTeams.Backend.WebApi.Infrastructure;
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
    public async Task<ActionResult<TeamDto>> GetById(int id)
      => TeamMapper.MapToDto(
          await _unitOfWork.TeamRepository
            .GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<TeamDto[]>> Get()
      => (await _unitOfWork.TeamRepository
          .GetAllAsync())
          .OrderBy(team => team.DisplayName)
          .Select(team => TeamMapper.MapToDto(team))
          .ToArray();

    [HttpGet("{id}/channels")]
    public async Task<ActionResult<ChannelDto[]>> GetChannelsByTeamId(int id)
      => (await _unitOfWork.ChannelRepository
          .GetByTeamIdAsync(id))
          .OrderBy(channel => channel.DisplayName)
          .Select(channel => ChannelMapper.MapToDto(channel))
          .ToArray();

    [HttpPost]
    public async Task<ActionResult<TeamDto>> Add(string displayName)
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
        TeamMapper.MapToDto(newTeam));
    }
  }
}
