using players_api.Models;
using System.Collections.Generic;

namespace players_api.Services
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        List<Player> CreatePlayer(Player player);
    }
}
