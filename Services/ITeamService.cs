using players_api.Models;
using System.Threading.Tasks;
using players_api.Dtos.Team;

namespace players_api.Services
{
    public interface ITeamService
    {
        Task<ServiceResponse<GetTeamDto>> CreateTeam(AddTeamDto team);
    }
}
