using GPSWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPSWebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Device>()
                .HasIndex(d => d.Serial)
                .IsUnique();

            builder.Entity<Device>()
                .HasOne(d => d.Vehicle)
                .WithOne(v => v.Device)
                .HasForeignKey<Vehicle>(v => v.DeviceId)
                .IsRequired(false);

            builder.Entity<Vehicle>()
                .HasOne(v => v.Device)
                .WithOne(d => d.Vehicle)
                .HasForeignKey<Device>(d => d.VehicleId)
                .IsRequired(false);
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Vehicle> Vehicles {  get; set; }
    }
}
