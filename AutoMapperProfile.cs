using AutoMapper;
using players_api.Models;
using players_api.Dtos.Player;
using players_api.Dtos.Team;

namespace players_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Player, GetPlayerDto>();
            CreateMap<AddPlayerDto, Player>();
            CreateMap<UpdatePlayerDto, Player>();
            CreateMap<Team, GetTeamDto>();
            CreateMap<AddTeamDto, Team>();
        }
    }
}
