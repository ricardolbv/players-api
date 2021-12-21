using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using players_api.Dtos.Player;

namespace players_api.Services
{
    public interface IPlayerService
    {
       Task<ServiceResponse<List<GetPlayerDto>>> GetAllPlayers();
       Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id);
       Task<ServiceResponse<List<GetPlayerDto>>> CreatePlayer(AddPlayerDto player);
    }
}
