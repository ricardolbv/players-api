using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace players_api.Services
{
    public class PlayerService : IPlayerService
    {
        private static List<Player> players = new List<Player>
        {
            new Player{Name = "Test1", Age = 17, Id = 1},
            new Player{Name = "Test2", Age = 18, Id = 2}
        };
        public async Task<ServiceResponse<List<Player>>> CreatePlayer(Player player)
        {
            var serviceResponse = new ServiceResponse<List<Player>>();
            players.Add(player);
            serviceResponse.Data = players;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Player>>> GetAllPlayers()
        {
            var serviceResponse = new ServiceResponse<List<Player>>();
            serviceResponse.Data = players;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Player>> GetPlayerById(int id)
        {
            var serviceResponse = new ServiceResponse<Player>();
            Player pl = players.Find(x => x.Id == id);
            serviceResponse.Data = pl;
                
            if(pl == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Data = null;

                return serviceResponse;
            }

            return serviceResponse;
        }
    }
}
