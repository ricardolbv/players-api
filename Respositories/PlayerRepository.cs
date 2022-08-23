using Dapper;
using players_api.Configuration;
using players_api.Dtos.Player;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace players_api.Respositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DapperContext _context;
        public PlayerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePlayer(AddPlayerDto player)
        {
            var statement = "INSERT INTO Characters (Name, Age) VALUES (@Name, @Age)";

            using (var connection = _context.CreateConnection())
            {
                var res = await connection.ExecuteAsync(statement, new { Name = player.Name, Age = player.Age });

                return res > 0;
            }
        }

        public async Task<bool> DeletePlayerById(int Id)
        {
            var statement = "DELETE FROM Characters WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var res = await connection.ExecuteAsync(statement, new { Id = Id });

                return res > 0;
            }
        }

        public async Task<IEnumerable<GetPlayerDto>> GetAllByUserId(int UserId)
        {
            var statement = "SELECT * FROM Characters WHERE UserId = @UserId";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<GetPlayerDto>(statement, new { UserId });
            }
        }

        public Task<GetPlayerDto> GetPlayerById(int Id, int UserId)
        {
            var statement = "SELECT * FROM Characters WHERE Id = @Id AND UserId = @UserId";

            using (var connection = _context.CreateConnection())
            {
                return connection.QueryFirstOrDefaultAsync<GetPlayerDto>(statement, new { Id = Id, UserId = UserId });
            }
        }

        public async Task<bool> UpdatePlayer(UpdatePlayerDto player)
        {
            var statement = "UPDATE Character SET Name = @Name, Age = @Age WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var res = await connection.ExecuteAsync(statement, new { Name = player.Name, Age = player.Age, Id = player.Id });

                return res > 0;
            }
        }
    }
}
