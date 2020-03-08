using System;
using System.Collections.Generic;


namespace CornNuggets
{
    class Program
    {
        static void Main(string[] args)
        {
            //call start menu for add/search/view/exit options
            Menu start = new Menu();
            Customer patron = new Customer();
            Store location = new Store();
            Product prod = new Product();
            //loop through menu options until exit
            string option;
            start.ShowMainMenu();
            option = start.GetInput("Enter the letter of your choice: ");
            do
            {
                
                switch (option)
                {
                    case "a":
                    {
                        //add menu option
                        start.ShowAddMenu();
                        break;
                    }
                    case "s":
                    {
                        //search menu option
                        start.ShowSearchMenu();
                        break;
                    }
                    case "v":
                    {
                        //view menu option
                        start.ShowViewMenu();
                        break;
                    }
                    case "b":
                    {
                        //go back to main menu
                        start.ShowMainMenu();
                        break;
                    }
                    case "n":
                    {
                        //new order request
                        start.ShowProductMenu();
                        int prodSelection = Convert.ToInt32(start.GetInput("Enter the item number"));
                        prod.BuyProduct(prodSelection);
                        break;
                    }
                    case "m":
                    {
                        //add new customer
                        string name = start.GetInput("Enter the new customer's name");
                        patron.AddCustomer(name);
                        start.ShowMainMenu();
                        break;
                    }
                    case "w":
                    {
                        //add new location
                        string name = start.GetInput("Enter the new store location name");
                        location.AddStore(name);
                        start.ShowMainMenu();
                        break;
                    }
                    case "c":
                    {
                        //search customer by name
                        string name = start.GetInput("Please enter the customers name");
                        patron.SearchCustomer(name);
                        start.ShowMainMenu();
                        break;
                    }
                    case "l":
                    {
                        //search for store location by name
                        string name = start.GetInput("Please enter the store name");
                        location.SearchStore(name);
                        start.ShowMainMenu();
                        break;
                    }
                    case "r":
                    {
                        //view order history
                        start.ShowOrdersBanner();
                        break;
                    }
                    case "u":
                    {
                        //show all customers that have been added
                        patron.DisplayCustomers();
                        start.ShowMainMenu();
                        break;
                    }
                    case "t":
                    {
                        //show  all locations that are currently in operation
                        location.DisplayStores();
                        start.ShowMainMenu();
                        break;
                    }
                    case "p":
                    {
                        //show  product menu with pricing
                        start.ShowProductMenu();
                        start.ShowMainMenu();
                        break;
                    }
                }
                option = start.GetInput("Enter the letter of your choice ");
            }while (option != "e");
            


        }
        static string GetInput(string message)
        {
            
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;

        }
    }
}
