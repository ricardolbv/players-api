using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using players_api.Dtos.Player;
using System.Linq;

namespace players_api.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;

        public PlayerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Player> players = new List<Player>
        {
            new Player{Name = "Test1", Age = 17, Id = 1},
            new Player{Name = "Test2", Age = 18, Id = 2}
        };
        public async Task<ServiceResponse<List<GetPlayerDto>>> CreatePlayer(AddPlayerDto player)
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();
            players.Add(_mapper.Map<Player>(player));

            serviceResponse.Data = players.Select(p =>
                _mapper.Map<GetPlayerDto>(p)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPlayerDto>>> GetAllPlayers()
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();
            serviceResponse.Data = players.Select(p =>
                _mapper.Map<GetPlayerDto>(p)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPlayerDto>();
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(players.First(p => p.Id == id));

            return serviceResponse;
        }
    }
}
