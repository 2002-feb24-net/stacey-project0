using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CornNuggets
{
    class Menu
    {
        /*Stacey Joseph, Revature, Project 0
         * Store Implementation
         * C:\Revature\stacey-project0\CornNuggets\Menu.cs
        */
        string Choice {get; set;}
        SecretConfig code = new SecretConfig();
        public Menu()
        {
            ShowBanner();
        }

        public string GetInput(string message)
        {
            Console.WriteLine(message);
            Choice = Console.ReadLine();
            return Choice;
        }
        
        public void ShowMainMenu() => Console.WriteLine("\nMain Menu options: a - add, s - search, v - view, e - exit: ");
        public void ShowBanner() => Console.WriteLine($"***************** Welcome to Corn Nuggets!*****************");
        public void ShowBanner(string menu) => Console.WriteLine($"\n*****************Corn Nuggets {menu} Menu*****************");

        public void ShowAddMenu() => Console.WriteLine("\nAdd options: n - new order, m - new customer, w - new location ");
        public void ShowSearchMenu()=> Console.WriteLine("\nSearch options: u - Customer, l - location, o - order, d - order details");
        public void ShowViewMenu() => Console.WriteLine("\nView options: r - store orders, c - all customers, t - customer order history,  e - EXIT");
        public void ShowNavMenu() => Console.WriteLine($"\n************Thank you for Choosing Corn Nuggets!************");
        public void ShowProductMenu()
        {
            
            Console.WriteLine("\nNuggets $4 ea: 111 - Habenero, 112 - Nacho, 113 - Blue, 114 - Tomato ");
            Console.WriteLine("Sauces $1 ea: 222 - Salsa, 223 - Avocado, 224 - Onion, 225 - Cheese ");
            Console.WriteLine("Drinks $2 ea: 333 - Fizzy, 334 - Tea, 335 - Juice, 336 - Smoothie ");
        }
        public void ShowOrdersBanner()
        {
            Console.WriteLine("Order Num  |  Date/Time  |  Store   | Total");
        }

        internal void ShowStores()
        {
             using 
            (SqlDataAdapter sqlda = new SqlDataAdapter("select * from NuggetStores", code.GetConnString()))
                {
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    foreach(DataRow row in dtbl.Rows)
                    {
                    Console.Write(row["StoreID"]);
                    Console.Write("  ");
                    Console.Write(row["StoreName"]);
                    Console.WriteLine();

                    }
                    //Console.ReadKey();
                }
        }
    }
}
