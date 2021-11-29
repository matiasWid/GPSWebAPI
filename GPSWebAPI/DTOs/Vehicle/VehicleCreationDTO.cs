using GPSWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.DTOs.Vehicle
{
    public class VehicleCreationDTO: ModelBase
    {
        private string _PlateNumber = "";
        [StringLength(15)]
        public string PlateNumber
        {
            get { return _PlateNumber; }
            set { _PlateNumber = value.ToUpper().Replace(" ", ""); }
        }
        public int? VehicleModelId { get; set; }
        public int? Year { get; set; }
        public int? InternalId { get; set; }

    }
}