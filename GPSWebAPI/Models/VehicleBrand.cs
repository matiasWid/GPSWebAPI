using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.Models
{
    public class VehicleBrand: ModelBase
    {
        [StringLength(50)]
        public string Description { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
    }
}
