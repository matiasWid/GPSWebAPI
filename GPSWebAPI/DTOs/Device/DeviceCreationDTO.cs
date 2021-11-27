using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.DTOs
{
    public class DeviceCreationDTO
    {
        [Required]
        [Range(1000000.0, long.MaxValue)]
        public long Serial { get; set; }
        [StringLength(3)]
        public string prueba { get; set; }
    }
}
