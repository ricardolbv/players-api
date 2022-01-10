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

namespace players_api.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public PlayerService(IMapper mapper, DataContext context, IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _context = context;
            _httpContext = httpContext;
        }

        private int GetUserId() => int.Parse(_httpContext.HttpContext.User
                                                         .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetPlayerDto>>> CreatePlayer(AddPlayerDto newPlayer)
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();
            Team team = await _context.Teams.FirstAsync(t => t.Id == newPlayer.TeamId);

            if(team == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Team not found";

                return serviceResponse; 
            }

            Player player = _mapper.Map<Player>(newPlayer);

            _context.Characters.Add(player);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Characters.Select(p =>
                _mapper.Map<GetPlayerDto>(p)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPlayerDto>>> GetAllPlayers()
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();

            var playersDb =  await _context.Characters.Where(p => p.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = playersDb.Select(p => _mapper.Map<GetPlayerDto>(p)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPlayerDto>();
            var dbCharacter = await _context.Characters
                                            .FirstOrDefaultAsync(p => p.Id == id && p.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetPlayerDto>(dbCharacter);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto player)
        {
            var serviceResponse = new ServiceResponse<GetPlayerDto>();
            var pl = _context.Characters
                             .FirstOrDefault(p => p.Id == player.Id && p.User.Id == GetUserId());

            pl.Name = player.Name;
            pl.Age = player.Age;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetPlayerDto>(pl);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPlayerDto>>> DeletePlayer(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();
            Player pl = _context.Characters.FirstOrDefault(p => p.Id == id &&
                                                           p.User.Id == GetUserId());
            _context.Characters.Remove(pl);
            await _context.SaveChangesAsync();  

            serviceResponse.Data = await _context.Characters.Select(p =>
                _mapper.Map<GetPlayerDto>(p)).ToListAsync();

            return serviceResponse;
        }
    }
}
