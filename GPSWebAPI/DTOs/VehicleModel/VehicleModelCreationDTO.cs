using GPSWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.DTOs.VehicleModel
{
    public class VehicleModelCreationDTO: ModelBase
    {
        [StringLength(50)]
        public string Description { get; set; }
    }
}
