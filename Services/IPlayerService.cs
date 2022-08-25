using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using players_api.Dtos.Player;

namespace players_api.Services
{
    public interface IPlayerService
    {
        Task<ServiceResponse<IEnumerable<GetPlayerDto>>> GetAllPlayers();
        Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id);
        Task<ServiceResponse<bool>> CreatePlayer(AddPlayerDto newPlayer);
        Task<ServiceResponse<bool>> UpdatePlayer(UpdatePlayerDto player);
        Task<ServiceResponse<bool>> DeletePlayer(int id);
    }
}
