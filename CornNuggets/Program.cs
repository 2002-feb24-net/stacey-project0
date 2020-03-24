using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornNuggets.Entities;


namespace CornNuggets
{
    class Program
    {
        /*Stacey Joseph, Revature, Project 0
         * Store Implementation
         * C:\Revature\stacey-project0\CornNuggets\Program.cs
        */
        static void Main(string[] args)
        {
            //set up the connection to the sql server
            string connStr = "Server=tcp:2020-training-stacey.database.windows.net,1433;Initial Catalog=CornNuggets;Persist Security Info=False;User ID=stacey;Password=Umbrella123();MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            /*using
            (SqlConnection sqlConn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand("Select * from Orders", sqlConn);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }
            */
            using 
            (SqlDataAdapter sqlda = new SqlDataAdapter("Select Firstname, Lastname, PreferredStore from Customers", connStr))
                {
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    foreach(DataRow row in dtbl.Rows)
                    {
                    Console.Write(row["FirstName"]);
                    Console.Write("  ");
                    Console.Write(row["LastName"]);
                    Console.Write("  ");
                    Console.Write(row["PreferredStore"]);
                    Console.WriteLine();

                    }
                    //Console.ReadKey();
                }
              
              
            
            //call start menu for add/search/view/exit options
            Menu start = new Menu();
            Customer patron = new Customer();
            Store location = new Store();
            Order items = new Order();
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
                        string customerName = start.GetInput("Please enter the customer's name");
                        if (patron.isCustomer(customerName))
                        {
                            string storeLocation = GetInput("Please enter the preferred store");
                            if (location.isStore(storeLocation))
                            {
                                start.ShowProductMenu();
                                int prodSelection;
                                do
                                {
                                prodSelection = Int32.Parse(start.GetInput("Enter the next item number or 999 to complete the order."));
                                if (new Product().isProduct(prodSelection))
                                {
                                    items.TakeOrder(customerName, storeLocation, prodSelection);
                                }
                                }while(prodSelection != 999);
                            }
                            else
                            {
                                System.Console.WriteLine("Store does not exist. Please add store.");
                            }
                            start.ShowOrdersBanner();
                            items.DisplayOrder();
                        }
                        else
                        {
                            System.Console.WriteLine("Customer does not exist. Please add customer.");
                        }
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
                        bool exists = patron.isCustomer(name);
                        if (exists)
                        {
                            Console.WriteLine($"Found Customer: {name}");
                        }
                        else
                        {
                            Console.WriteLine($"No match found. Please add {name}.");

                        }
                        start.ShowMainMenu();
                        break;
                    }
                    case "l":
                    {
                        //search for store location by name
                        string name = start.GetInput("Please enter the store name");
                        bool valid = location.isStore(name);
                        if (valid)
                        {
                            Console.WriteLine("Store Location found");
                        }
                        else
                        {
                            System.Console.WriteLine("Location does not exist. Please add store.");
                        }
                        start.ShowMainMenu();
                        break;
                    }
                    case "r":
                    {
                        //view order history
                        start.ShowOrdersBanner();
                        items.DisplayOrder();
                        start.ShowMainMenu();
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
                    case "e":
                    {
                        //exit the loop 
                        start.ShowNavMenu();
                        System.Environment.Exit(0);
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
        
        static DataSet DataSetSelectRows(DataSet dataset, string connectionString, string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("", connection);
                adapter.Fill(dataset);
                return dataset;
            }
        }
    }
}
