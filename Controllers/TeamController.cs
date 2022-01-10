using Microsoft.AspNetCore.Mvc;
using players_api.Data;
using players_api.Models;
using System.Threading.Tasks;
using players_api.Dtos.Team;
using Microsoft.AspNetCore.Authorization;
using players_api.Services;

namespace players_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        public ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetTeamDto>>> CreateTeam(AddTeamDto team)
        {
            return Ok(await _teamService.CreateTeam(team));
        }
    }
}
