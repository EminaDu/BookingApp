using BookingApp.Data;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingApp
{
    internal class Input
    {
        internal static void AddNewService()
        {
            using (var database = new Data.Context())
            {
                var service = new Service();
                service.Title = Helpers.GetValidString("Enter Title: ");
                service.Name = Helpers.GetValidString("Enter Name: ");
                service.Description = Helpers.GetValidString("Enter Description: ");
                service.Price = Helpers.GetValidDouble("Enter Price:");
                database.Add(service);
                try
                {
                    database.SaveChanges();
                    Console.WriteLine("Save success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not save values to database" + ex);
                }
            }
        }
        internal static void BookService()
        {
            using (var database = new Data.Context())
            {
                string name = Helpers.GetValidString("Enter your firstname: ");
                string lastName = Helpers.GetValidString("Enter your lastname: ");
                string city = Helpers.GetValidString("Enter your city: ");
                int day = Helpers.GetValidInt("Choose a day(1-7): ");
                int serviceId = Helpers.GetValidInt("Choose service Id:");
                int week = Helpers.GetValidInt("Choose week:");
                var services = database.Services
                    .Include(x => x.Bookings)
                    .ToList();
                var booking = database.Bookings
                    .Where(x => x.Day.Equals((DayOfWeek)day) && x.Week.Equals(week) && x.Service.Id.Equals(serviceId))
                    .ToList()
                    .Any();
                var newCustomer = new Customer()
                {
                    FirstName = name,
                    LastName = lastName,
                    City= city,
                };
                database.Add(newCustomer);
                var newBooking = new Booking()
                {
                    Day = (DayOfWeek)day,
                    ServiceId = serviceId,
                    Customer = newCustomer,
                    Week = week,
                    BookingDate = DateTime.Now,
                };
                database.Add(newBooking);
                try
                {
                    database.SaveChanges();
                    Console.WriteLine("Save success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not save values to database" + ex);
                }
            }
        }
    }
}
