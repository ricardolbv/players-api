using System.Collections.Generic;
using players_api.Dtos.Player;

namespace players_api.Dtos.Team
{
    public class GetTeamDto
    {
        public string Name { get; set; }
        public List<GetPlayerDto> players { get; set; }
    }
}
