using Microsoft.EntityFrameworkCore;
using GrepolisTools.Models;

namespace GrepolisTools.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
    }
}
