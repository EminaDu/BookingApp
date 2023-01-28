using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    internal class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public int Week { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime BookingDate { get; set; }
        public virtual Customer Customer { get; set; } = null!; 
        public virtual Service Service { get; set; }
    }
}
