using System.ComponentModel.DataAnnotations;

namespace GPSWebAPI.Models
{
    public class Vehicle : ModelBase
    {
        private string _PlateNumber = "";
        [StringLength(15)]
        public string PlateNumber
        {
            get { return _PlateNumber; }
            set { _PlateNumber = value.ToUpper().Replace(" ", ""); }
        }
        public string Brand { get; set; }
        public int? DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
