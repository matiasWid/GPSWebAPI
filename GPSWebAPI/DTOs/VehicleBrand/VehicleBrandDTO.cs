using GPSWebAPI.DTOs.VehicleModel;
using GPSWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.DTOs.VehicleBrand
{
    public class VehicleBrandDTO: ModelBase
    {        
        [StringLength(50)]
        public string Description { get; set; }
        public List<VehicleModelDTO> VehicleModels { get; set; }
    }
}
