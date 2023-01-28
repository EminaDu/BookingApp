using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    internal class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        
        

    }
}
