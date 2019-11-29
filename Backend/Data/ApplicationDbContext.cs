using Backend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    /// <summary>
    /// Dit is onze database voor in de backend.
    /// Regels of relaties tussen tabellen kan je in de methode OnModelCreating toevoegen
    /// </summary>
    public sealed class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<AttemptDevice> AttemptDevices { get; set; }
        public DbSet<GameSequence> GameSequences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Device>().HasIndex(c => c.MacAddress).IsUnique();

            builder.Entity<AttemptDevice>().HasKey(c => new {c.AttemptId, MacAddress = c.DeviceId});
            builder.Entity<AttemptDevice>().HasOne(c => c.Attempt)
                .WithMany(c => c.AttemptDevices)
                .HasForeignKey(c => c.AttemptId);
//            builder.Entity<AttemptDevice>().HasOne(c => c.Device)
//                .WithMany(c => c.AttemptDevices)
//                .HasForeignKey(c => c.DeviceId);

//            builder.Entity<Attempt>().HasMany(a => a.AttemptDevices);
        }
    }
}