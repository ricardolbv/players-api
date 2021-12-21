using AutoMapper;
using players_api.Models;
using players_api.Dtos.Player;

namespace players_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Player, GetPlayerDto>();
            CreateMap<AddPlayerDto, Player>();
        }
    }
}
