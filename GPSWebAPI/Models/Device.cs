using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.Models
{
    public class Device: ModelBase
    {
        [Required]
        [Range(1000000.0, long.MaxValue)]
        public long Serial { get; set; }
        [StringLength(3)]
        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
