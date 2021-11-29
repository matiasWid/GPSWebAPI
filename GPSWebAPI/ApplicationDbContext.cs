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

            builder
                .Entity<Device>()
                .HasOne(d => d.Vehicle)
                .WithOne(v => v.Device)
                .HasForeignKey<Vehicle>(v => v.DeviceId)
                .IsRequired(false);

            builder
                .Entity<Vehicle>()
                .HasOne(v => v.Device)
                .WithOne(d => d.Vehicle)
                .HasForeignKey<Device>(d => d.VehicleId)
                .IsRequired(false);
            
            builder
                .Entity<VehicleBrand>()
                .HasIndex(vb => vb.Description)
                .IsUnique();
            
            builder
                .Entity<VehicleModel>()
                .HasIndex(vm => vm.Description)
                .IsUnique();
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Vehicle> Vehicles {  get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
