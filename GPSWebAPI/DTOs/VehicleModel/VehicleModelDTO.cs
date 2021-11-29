using GPSWebAPI.DTOs.VehicleBrand;

namespace GPSWebAPI.DTOs.VehicleModel
{
    public class VehicleModelDTO
    {
        public string Description { get; set; }
        public int VehicleBrandId { get; set; }
        public VehicleBrandDTO VehicleBrand { get; set; }
    }
}
