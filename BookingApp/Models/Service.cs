using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    internal class Service
    {
        public Service()
        {
            Bookings= new HashSet <Booking>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } 
        
        public virtual ICollection<Booking> Bookings { get; set;}


    }
}
