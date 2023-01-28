using BookingApp.Data;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp
{
    internal class Helpers
    {
        public static string GetValidString(string newstring)
        {
            Console.Write(newstring);
            var customerInput = Console.ReadLine();
            while (string.IsNullOrEmpty(customerInput))
            {
                TryAgain();
                customerInput = Console.ReadLine();
            }
            return customerInput;
        }
        public static double GetValidDouble(string newstring)
        {
            Console.Write(newstring);
            double customerInput;
            while (!double.TryParse(Console.ReadLine(), out customerInput))
            {
                TryAgain();
            }
            return customerInput;
        }
        public static int GetValidInt(string newstring)
        {
            Console.Write(newstring);
            int customerInput;
            while (!int.TryParse(Console.ReadLine(), out customerInput))
            {
                TryAgain();
            }
            return customerInput;
        }
        public static void TryAgain()
        {
            Console.WriteLine("Invalid input, try again! ");
        }
        internal static void InputServices()
        {
            using (var database = new Context())
            {
                List<Service> services = new List<Service>
                {
                new Service()
                {
                    Title = "Hairdresser",
                    Name = "Hair clipping",
                    Description = " Cutting hair of different lengths of hair by different methods.",
                    Price = 300
                },

                new Service()
                {
                    Title = "Hairdresser",
                    Name = "Hair dyeing",
                    Description = " Dyeing hair of different lengths in meny different colors and by different methods.",
                    Price = 1800
                },

                new Service()
                {
                    Title = "Hairdresser",
                    Name = "Hair drying",
                    Description = " Drying hair of different lengths with different methods.",
                    Price = 1000
                },

                new Service()
                {
                    Title = "Massage",
                    Name = "Classic massage",
                    Description = "45 min relaxing massage.",
                    Price = 500
                },

                new Service()
                {
                    Title = "Massage",
                    Name = "Hellbody massage",
                    Description = "60 min hellbody massage.",
                    Price = 700
                },

                new Service()
                {
                    Title = "Massage",
                    Name = "Face massage",
                    Description = "efreshing and relaxing facial massage.",
                    Price = 400.0
                },

                new Service()
                {
                    Title = "Depilation",
                    Name = "Waxing",
                    Description = "Different body parths.Price is per parth.",
                    Price = 800.0
                },

                new Service()
                {
                     Title = "Depilation",
                     Name = "Depilation with sugar paste",
                     Description = "Different body parths. Prise is per parth.",
                     Price = 400.0
                },

                new Service()
                {
                     Title = "Depilation",
                     Name = "Depilation with laser",
                     Description = "Different body parths.Price is per parth.",
                     Price = 500.0
                }
                };
                foreach (Service service in services)
                {
                    var newService = service;
                    var databaseNewService = database.Services;
                    databaseNewService.Add(newService);
                }
                try
                {
                    database.SaveChanges();
                    Console.WriteLine("Successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not save values to database" + ex);
                }
            }
        }
    }
}