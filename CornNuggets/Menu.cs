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

        public void ShowAddMenu() => Console.WriteLine("Add options: o - order, c - customer, l - location, b - back: ");
        public void ShowSearchMenu()=> Console.WriteLine("Search options: c - customer, l - location, o - order, b - back");
        public void ShowViewMenu() => Console.WriteLine("View options: o - orders, c - customers, l - locations, b - back");
        public void ShowNavMenu(string menu) => Console.WriteLine($"*****************Thank you for Choosing Corn Nuggets!*****************");

    }
}
