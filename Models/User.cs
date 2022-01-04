using System.Collections.Generic;

namespace players_api.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PassworldSalt { get; set; }
        public List<Player> Players { get; set; }
    }
}
