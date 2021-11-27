using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.DTOs
{
    public class DeviceVehicleDTO
    {
        public int DeviceId { get; set; }
        public int VehicleId { get; set; }
        //[Display(ResourceType = typeof(VehicleDTO))]
        public string VehiclePlate { get; set; }
        public Int64 DeviceSerial { get; set; }
    }
}
