using System.Collections.Generic;

namespace players_api.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public User User { get; set; }  
        public int UserId { get; set; }
    }
}
