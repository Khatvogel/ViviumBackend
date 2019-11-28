using Backend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    /// <summary>
    /// Dit is onze database voor in de backend.
    /// Regels of relaties tussen tabellen kan je in de methode OnModelCreating toevoegen
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> ConnectedDevices { get; set; }
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<AttemptDevice> AttemptDevices { get; set; }
        public DbSet<GameSequence> GameSequences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Device>()
                .HasKey(c => c.MacAddress);
            builder.Entity<GameSequence>().HasKey(x => x.MacAddress);

            builder.Entity<AttemptDevice>().HasKey(c => new {c.AttemptId, MacAddress = c.DeviceMacAddress});
            builder.Entity<AttemptDevice>().HasOne(c => c.Attempt);
            builder.Entity<AttemptDevice>().HasOne(c => c.Device);
        }
    }
}