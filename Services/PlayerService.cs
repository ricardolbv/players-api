using players_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using players_api.Dtos.Player;
using System.Linq;
using players_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using players_api.Respositories;

namespace players_api.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IPlayerRepository _plRepository;

        public PlayerService(IMapper mapper, DataContext context, IHttpContextAccessor httpContext,
                IPlayerRepository playerRepository)
        {
            _mapper = mapper;
            _context = context;
            _httpContext = httpContext;
            _plRepository = playerRepository;
        }

        private int GetUserId() => int.Parse(_httpContext.HttpContext.User
                                                         .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<bool>> CreatePlayer(AddPlayerDto newPlayer)
        {
            var serviceResponse = new ServiceResponse<bool>();
            Team team = await _context.Teams.FirstAsync(t => t.Id == newPlayer.TeamId);

            if(team == null)
            {
                serviceResponse.Data = false;
                serviceResponse.Success = false;
                serviceResponse.Message = "Team not found";

                return serviceResponse; 
            }

            Player player = _mapper.Map<Player>(newPlayer);

            var res = await _plRepository.CreatePlayer(newPlayer);
            if (res)
            {
                serviceResponse.Data = res;
            }
            else
            {
                serviceResponse.Data = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetPlayerDto>>> GetAllPlayers()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetPlayerDto>>();
            serviceResponse.Data = await _plRepository.GetAllByUserId(GetUserId());

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPlayerDto>();
            serviceResponse.Data = await _plRepository.GetPlayerById(id, GetUserId());

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> UpdatePlayer(UpdatePlayerDto player)
        {
            var serviceResponse = new ServiceResponse<bool>();
            serviceResponse.Data = await _plRepository.UpdatePlayer(player);

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeletePlayer(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();
            serviceResponse.Data = await _plRepository.DeletePlayerById(id);

            return serviceResponse;
        }
    }
}
