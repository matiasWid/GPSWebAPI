using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.Models
{
    public class VehicleModel: ModelBase
    {
        [StringLength(50)]
        public string Description { get; set; }
        public int VehicleBrandId { get; set; }
        public VehicleBrand VehicleBrand { get; set; }
    }
}
