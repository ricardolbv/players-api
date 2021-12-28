using Microsoft.EntityFrameworkCore;
using players_api.Models;

namespace players_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Player> Characters { get; set; }
    }
}
