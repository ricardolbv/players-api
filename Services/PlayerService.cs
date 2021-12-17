using players_api.Models;
using System.Collections.Generic;

namespace players_api.Services
{
    public class PlayerService : IPlayerService
    {
        private static List<Player> players = new List<Player>
        {
            new Player{Name = "Test1", Age = 17, Id = 1},
            new Player{Name = "Test2", Age = 18, Id = 2}
        };
        public List<Player> CreatePlayer(Player player)
        {
            players.Add(player);
            return players;
        }

        public List<Player> GetAllPlayers()
        {
            return players;
        }

        public Player GetPlayerById(int id)
        {
            Player pl = players.Find(x => x.Id == id);
                
            if(pl == null)
                return null;

            return pl;
        }
    }
}
