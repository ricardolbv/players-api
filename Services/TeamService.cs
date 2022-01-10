using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using players_api.Data;
using players_api.Dtos.Team;
using players_api.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace players_api.Services
{
    public class TeamService : ITeamService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public TeamService(DataContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext.User
                                                        .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetTeamDto>> CreateTeam(AddTeamDto team)
        {
            var response = new ServiceResponse<GetTeamDto>();
            Team newTeam = _mapper.Map<Team>(team);
            newTeam.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetTeamDto>(newTeam);

            return response;
        }
    }
}
