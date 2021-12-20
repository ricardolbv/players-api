using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace players_api.Services
{
    public interface IPlayerService
    {
       Task<ServiceResponse<List<Player>>> GetAllPlayers();
       Task<ServiceResponse<Player>> GetPlayerById(int id);
       Task<ServiceResponse<List<Player>>> CreatePlayer(Player player);
    }
}
