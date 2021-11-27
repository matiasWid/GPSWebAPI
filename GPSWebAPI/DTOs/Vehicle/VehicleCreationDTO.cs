using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.DTOs
{
    public class VehicleCreationDTO
    {
        private string _PlateNumber = "";
        [StringLength(15)]
        public string PlateNumber
        {
            get { return _PlateNumber; }
            set { _PlateNumber = value.ToUpper().Replace(" ", ""); }
        }
        public string Brand { get; set; }

    }
}