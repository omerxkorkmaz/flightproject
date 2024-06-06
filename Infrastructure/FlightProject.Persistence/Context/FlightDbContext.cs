using FlightProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Persistence.Context
{
    public class FlightDbContext : DbContext
    {

        public FlightDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Ticket ilişkisi
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            // Flight - Ticket ilişkisi
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Tickets)
                .WithOne(t => t.Flight)
                .HasForeignKey(t => t.FlightId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
