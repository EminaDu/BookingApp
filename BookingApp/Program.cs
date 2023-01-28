namespace BookingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            //Helpers.InputServices(); // fyll på service
            menu.ShowMenu();
        }
    }
}