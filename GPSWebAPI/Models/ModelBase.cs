using System.ComponentModel;

namespace GPSWebAPI.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        [DefaultValue(true)]
        public bool Active { get; set; } = true;    
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
