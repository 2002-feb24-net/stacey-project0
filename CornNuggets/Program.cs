using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornNuggets;


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
            SecretConfig connStr = new SecretConfig();
  
            //Select * from Orders where StoreID=1
            //1. add new Customer options: a --> m
            //2. display all order history of a customer options -->
            //3. Search customers by name
            //4. place orders to store locations for customers
            //5. display all order history of a store
            //6. display details of an order

            //call start menu for add/search/view/exit options
            Menu start = new Menu();
            Customer patron = new Customer();
            Store location = new Store();
            Order items = new Order();

            //essential parameters
            string fname;
            string lname;
            string pstore;
            int custID;
            int prodID;
            int prodQty;
            int storeID;
            int orderID;

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
                        //custID = GetInput("Please enter the customer's id:")
                        //pstore = GetInput("Please enter the preferred store");
                        ProcessMenuSelection(option);
                            
                        start.ShowProductMenu();
                        prodID = int.Parse(GetInput("Please enter the product number: "));
                        do
                        {
                            /*    
                            try
                            {
                                prodID = Int32.Parse(start.GetInput("Enter the next item number or 999 to complete the order."));
                            }    
                            catch (exception e)
                            {
                                    Console.WriteLine("Invalid number");
                            }*/
                            ProcessMenuSelection(option);
                        }while(prodID != 999);
                    break;
                    } 
                    case "m":
                    {
                        //add new customer
                        fname = start.GetInput("Enter the new customer's first name");
                        lname = start.GetInput("Enter the new customer's last name");
                        pstore = start.GetInput("Enter the new customer's Preferred Store");
                        patron.AddCustomer(fname, lname, pstore);
                        start.ShowMainMenu();
                        break;
                    }
                    case "w":
                    {
                        //add new location
                        pstore = start.GetInput("Enter the new store location name");
                        location.AddStore(pstore);
                        start.ShowMainMenu();
                        break;
                    }
                    case "c":
                    {
                        //search customer by name
                        //add new customer
                        fname = start.GetInput("Enter the new customer's first name");
                        lname = start.GetInput("Enter the new customer's last name");
                        //patron.SearchCustomer(fname, lname);
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
                        //patron.ShowAllCustomers();
                        ProcessMenuSelection(option);
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
                    case "d":
                    {
                        //search customer by name
                        //add new customer
                        fname = start.GetInput("Enter the new customer's first name");
                        lname = start.GetInput("Enter the new customer's last name");
                        //patron.SearchCustomer(fname, lname);
                        ProcessMenuSelection(option);
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
                option = start.GetInput(" ");
            }while (option != "e");
        
        
        static void ProcessMenuSelection(string selection)
        {
            string result;

            if (selection ==  "m"){result = "dbo.spCustomers_AddNew";}
            else if (selection == "t"){result = "dbo.spCustomers_DisplayOrdersByID"; }
            else if (selection == "u"){result = "dbo.spCustomer_GetByFullName";}
            else if (selection == "n"){result = "dbo.spOrders_PlaceToStoreForCustomer";}
            else if (selection == "r"){result = "dbo.spOrders_GetAllByStore";}
            else if (selection == "d"){result = "dbo.spOrders_GetDetails"; }
            else  {return;}
            SecretConfig connStr = new SecretConfig();
            using 
            (SqlDataAdapter sqlda = new SqlDataAdapter(result, connStr.GetConnString()))
                {
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    foreach(DataRow row in dtbl.Rows)
                    {
                    Console.Write(row["OrderID"]);
                    Console.Write("  ");
                    Console.Write(row["DateTimeStamp"]);
                    Console.Write("  ");
                    Console.Write(row["OrderID"]);
                    Console.Write("  ");
                    Console.Write(row["StoreID"]);
                    Console.Write("  ");
                    Console.Write(row["Total"]);
                    Console.WriteLine();

                    }
                    //Console.ReadKey();
                }
        }
        static string GetInput(string message)
        {
            
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;

        }
        
    }

    
    }}
