using System.Collections.Generic;
using System;


namespace CornNuggets
{
    class Menu
    {
        public int customerID;
        string choice;
        static List<string> selection = new List<string>() {"a", "s","v","e","b"};

        public Menu()
        {
            ShowBanner();
        }

        public string GetInput(string message)
        {
            Console.WriteLine(message);
            string choice = Console.ReadLine();
            return choice;
        }
        
        public void ShowMainMenu() => Console.WriteLine("Main options: a - add, s - search, v - view, e - exit: ");
        public void ShowBanner() => Console.WriteLine($"***************** Welcome to Corn Nuggets!*****************");
        public void ShowBanner(string menu) => Console.WriteLine($"*****************Corn Nuggets {menu} Menu*****************");

        public void ShowAddMenu() => Console.WriteLine("Add options: n - new order, m - new customer, w - new location, b - back ");
        public void ShowSearchMenu()=> Console.WriteLine("Search options: c - Customer, l - location, o - order, b - back");
        public void ShowViewMenu() => Console.WriteLine("View options: r - orders, u - customers, t - locations, b - back");
        public void ShowNavMenu() => Console.WriteLine($"************Thank you for Choosing Corn Nuggets!************");
        public void ShowProductMenu()
        {
            Console.WriteLine("Nuggets $4 ea: 111 - Habenero, 112 - Nacho, 113 - Blue, 114 - Tomato ");
            Console.WriteLine("Sauces $1 ea: 222 - Salsa, 223 - Avocado, 224 - Onion, 225 - Cheese ");
            Console.WriteLine("Drinks $2 ea: 333 - Fizzy, 334 - Tea, 335 - Juice, 336 - Smoothie ");
        }
        public void ShowOrdersBanner()
        {
            Console.WriteLine("Date |   Order Num  |  Store  |   Customer    |   Total");
        } 

    }
}
