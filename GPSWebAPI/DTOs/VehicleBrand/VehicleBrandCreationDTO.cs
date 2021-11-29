using GPSWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.DTOs.VehicleBrand
{
    public class VehicleBrandCreationDTO
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool Active { get; set; } = true;
    }
}
