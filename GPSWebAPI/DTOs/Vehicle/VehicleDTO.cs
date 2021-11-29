using GPSWebAPI.DTOs.Device;
using GPSWebAPI.DTOs.VehicleModel;
using GPSWebAPI.Models;

namespace GPSWebAPI.DTOs.Vehicle
{
    public class VehicleDTO: ModelBase
    {
        public string PlateNumber { get; set; }
        public DeviceDTO Device { get; set; }
        public VehicleModelDTO VehicleModel { get; set; }
        public int? Year { get; set; }
        public int? InternalId { get; set; }
    }
}
