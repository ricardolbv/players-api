using players_api.Dtos.Player;
using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace players_api.Respositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<GetPlayerDto>> GetAllByUserId(int UserId);
        Task<bool> CreatePlayer(AddPlayerDto player);
        Task<GetPlayerDto> GetPlayerById(int Id, int UserId);
        Task<bool> DeletePlayerById(int Id);
        Task<bool> UpdatePlayer(UpdatePlayerDto player);
    }
}
