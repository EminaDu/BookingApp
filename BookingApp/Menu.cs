using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp
{
    internal class Menu
    {
        enum MenuChoice
        {
            Admin = 1,
            Customer,
            Quit
        }
        enum AdminMenu
        {
            Add_new_service = 1,
            Show_all_booknings,
            Most_popular_service,
            Person_who_booked_the_most,
            Back,
            Quit
        }
        enum CustomerMenu
        {
            Book = 1,
            Back,
            Quit
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                ShowLogo();
                foreach (int i in Enum.GetValues(typeof(MenuChoice)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuChoice), i).Replace('_', ' ')}");
                }
                int nr;
                MenuChoice menu = (MenuChoice)3;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (MenuChoice)nr;
                    Console.Clear();
                }
                else
                {
                    Helpers.TryAgain();
                }
                switch (menu)
                {
                    case MenuChoice.Admin:
                        ShowAdminMenu();
                        break;
                    case MenuChoice.Customer:
                        ShowCustomerMenu();
                        break;
                    case MenuChoice.Quit:
                        running = false;
                        break;
                }
            }
        }
        public void ShowAdminMenu()
        {
            bool running = true;
            while (running)
            {
                ShowLogo();
                foreach (int i in Enum.GetValues(typeof(AdminMenu)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(AdminMenu), i).Replace('_', ' ')}");
                }
                int nr;
                AdminMenu menu = (AdminMenu)99;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (AdminMenu)nr;

                    Console.Clear();
                }
                else
                {
                    Helpers.TryAgain();
                }
                switch (menu)
                {
                    case AdminMenu.Add_new_service:
                        Input.AddNewService();
                        Console.Clear();
                        break;
                    case AdminMenu.Show_all_booknings:
                        Output.ShowAllBookings();
                        break;
                    case AdminMenu.Most_popular_service:
                        Output.ShowMostPopularServices();
                        break;
                    case AdminMenu.Person_who_booked_the_most:
                        Output.ShowCustomerWithMostBooknings();
                        break;
                    case AdminMenu.Back:
                        ShowMenu();
                        break;
                    case AdminMenu.Quit:
                        running = false;
                        break;
                }
            }
        }
        public void ShowCustomerMenu()
        {
            bool running = true;
            while (running)
            {
                ShowLogo();
                foreach (int i in Enum.GetValues(typeof(CustomerMenu)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(CustomerMenu), i).Replace('_', ' ')}");
                }
                int nr;
                CustomerMenu menu = (CustomerMenu)99;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (CustomerMenu)nr;
                    Console.Clear();
                }
                else
                {
                    Helpers.TryAgain();
                }
                switch (menu)
                {
                    case CustomerMenu.Book:
                        Output.ShowServices();
                        Input.BookService();
                        Console.Clear();
                        break;
                    case CustomerMenu.Back:
                        ShowMenu();
                        break;

                    case CustomerMenu.Quit:
                        running = false;
                        break;
                }
            }
        }
        private static void ShowLogo()
        {
            Console.WriteLine("\tBEAUTY SALONG");
        }
    }
}
