using Laboration_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Laboration_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
              Database=BradhornanDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;");
        }
    }
}