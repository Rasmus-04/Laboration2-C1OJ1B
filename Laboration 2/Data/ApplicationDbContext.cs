using Laboration_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Laboration_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventMember> EventMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
              Database=BradhornanDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventMember>()
                .HasKey(em => new { em.EventId, em.MemberId });

            modelBuilder.Entity<EventMember>()
                .HasOne(em => em.Event)
                .WithMany(e => e.EventMembers)
                .HasForeignKey(em => em.EventId);

            modelBuilder.Entity<EventMember>()
                .HasOne(em => em.Member)
                .WithMany(m => m.EventMembers)
                .HasForeignKey(em => em.MemberId);
            
            modelBuilder.Entity<Event>().Ignore(e => e.Participants);
        }
    }
}