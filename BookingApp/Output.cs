using BookingApp.Data;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp
{
    internal class Output
    {
        internal static void ShowMostPopularServices()
        {
            using (var database = new Data.Context())
            {
                var bookedServices = database.Services
                    .Include(x => x.Bookings)
                    .ToList();
                var result = bookedServices
                    .OrderByDescending(x => x.Bookings.Count)
                    .Take(3);
                foreach (var r in result)
                {
                    Console.WriteLine("Our most popular services:" + r.Title + " \t " + r.Name + ". Has been booked: " + r.Bookings.Count + " times.");
                }
            }
        }
        internal static void ShowCustomerWithMostBooknings()
        {
            using (var database = new Context())
            {
                var customer = database.Customers
                    .Include(c => c.Bookings)
                    .ToList();
                var result = customer
                    .OrderByDescending(c => c.Bookings.Count())
                    .FirstOrDefault();
                foreach (var r in customer)
                {
                    Console.WriteLine("The customer: " + r.FirstName + "\t" + r.LastName + " has the most booknings.");
                }
            }
        }
        internal static void ShowAllBookings()
        {
            using (var database = new Context())
            {
                var query = from
                                b in database.Bookings
                            join
                               c in database.Customers
                               on b.CustomerId equals c.Id
                            join
                               s in database.Services
                               on b.ServiceId equals s.Id

                            select new
                            {
                                CustomerName = c.FirstName + "\t " + c.LastName,
                                TypOfService = s.Title,
                                TretmanName = s.Name,
                                CustomerId = c.Id,
                                b.BookingDate,
                                b.Week,
                                b.Day,
                                b.Id
                            };
                Console.WriteLine("Customer " + " \t\t" + "Typ of service" + " \t\t" + "Tretman" + "  \t\t" + "Week" + " \t" + "Day" + "\t" + " Booknings date");
                Console.WriteLine();
                foreach (var q in query)
                {
                    Console.WriteLine(q.Id + " " + q.CustomerName + "\t\t" + q.TretmanName + " \t\t" + q.TypOfService + " \t\t" + q.Week + "\t\t" + q.Day + "\t" + q.BookingDate);
                }
            }
        }
        public static void ShowServices()
        {
            using (var database = new Data.Context())
            {
                var services = database.Services
                    .ToList();
                Console.WriteLine("Services: ");
                foreach (var service in services)
                {
                    Console.WriteLine(service.Id + "   \t" + service.Title + "\t\t" + service.Name + "\t\t" + service.Price);
                }
            }
        } 
    }
}