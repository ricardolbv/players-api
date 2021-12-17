using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace players_api.Services
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Task<List<Player>> CreatePlayer(Player player);
    }
}
