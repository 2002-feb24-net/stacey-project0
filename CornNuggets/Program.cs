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
            //2. display all order history of a customer options --> t
            //3. Search customers by name --> 
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
            //int custID;
            int prodID;
            int prodQty;
            int storeID;
            int orderID = 1001;

            //loop through menu options until exit
            string option;
            
            fname = start.GetInput("Enter your first name");
            lname = start.GetInput("Enter your last name");

            start.ShowBanner("Options");
            //start.ShowMainMenu();
            start.ShowAddMenu();
            start.ShowSearchMenu();
            start.ShowViewMenu();
            Console.WriteLine();
            do
            {
                option = start.GetInput($"Enter your menu choice {fname}: ");
                if (option =="t"){ProcessMenuSelectionT(option);}
                else if (option == "u"){ProcessMenuSelectionU(option);}
            }while(option!="e");
            
            Environment.Exit(0);
            string result;

            SqlConnection conn = new SqlConnection(connStr.GetConnString());
            if (option == "t")//display all order history of a customer
            { 
                result = "dbo.spCustomers_DisplayOrdersByID";
            }
            else if (option == "u"){ result = "dbo.spCustomer_GetByFullName";}
            else if (option == "n"){result = "dbo.spOrders_PlaceToStoreForCustomer";}
            else if (option == "r"){result = "dbo.spOrders_GetAllByStore";}
            else if (option == "d"){result = "dbo.spOrders_GetDetails"; }
            else  {return;}
            SqlCommand cmd = new SqlCommand(result, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param1 =  new SqlParameter();
            SqlParameter param2 =  new SqlParameter();
            SqlParameter param3 =  new SqlParameter();
            param1 = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            param2 = cmd.Parameters.Add("@LastName",SqlDbType.NVarChar, 50);
            param3 = cmd.Parameters.Add("@PreferredStore",SqlDbType.NVarChar, 7);

            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            param3.Direction = ParameterDirection.Input;

            //param1.Value = custID;
            //param2.Value = items[1];
            //param3.Value = items[2];

            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write(" ");
                Console.Write(reader[1].ToString());
                Console.Write(" ");
                Console.WriteLine(reader[2].ToString());
            }
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();

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
                        //new order request dbo.spOrders_PlaceToStoreForCustomer
                        start.ShowStores();
                        pstore = start.GetInput($"Enter {fname} {lname}'s Preferred Store");
                        start.ShowProductMenu();
                        prodID = int.Parse(GetInput("Please enter a product number or 999 to cancel transaction: "));
                        if (prodID != 999) 
                        {
                            prodQty = Int32.Parse(start.GetInput("How many? "));
                            items.CreateOrder(fname, lname, prodID, prodQty);
                        }
                        do
                        {      
                            try
                            {
                                start.ShowProductMenu();
                                prodID = Int32.Parse(start.GetInput("Enter the next item number or 999 to complete the order."));
                                
                            }    
                            catch (Exception)
                            {
                                    Console.WriteLine("Invalid number");
                            }
                        }while(prodID != 999);

                        if (prodID!=999) 
                        {
                            items.DisplayOrder(orderID);
                        }
                        break;
                    } 
                    case "m":
                    {
                        //add new customer
                        fname = start.GetInput("Enter the new customer's first name");
                        lname = start.GetInput("Enter the new customer's last name");
                        start.ShowStores();
                        pstore = start.GetInput($"Enter {fname} {lname}'s Preferred Store");
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
                        fname = start.GetInput("Enter the new customer's first name");
                        lname = start.GetInput("Enter the new customer's last name");
                        patron.SearchCustomer(fname, lname);
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
                        //view order history by store
                        start.ShowStores();
                        storeID = int.Parse(GetInput("Enter the store ID: "));
                        start.ShowOrdersBanner();
                        //items.DisplayOrder(orderID);
                        start.ShowMainMenu();
                        break;
                    }
                    case "u":
                    {
                        //show all customers that have been added
                        patron.ShowAllCustomers();
                        start.ShowMainMenu();
                        break;
                    }
                    case "t":
                    {
                        //show  all locations that are currently in operation
                        start.ShowStores();
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
                        orderID= int.Parse(GetInput("Please enter the order number"));
                        items.DisplayOrder(orderID);
                        //search customer by name
                        //add new customer
                        //fname = start.GetInput("Enter the new customer's first name");
                        //lname = start.GetInput("Enter the new customer's last name");
                        //patron.SearchCustomer(fname, lname);
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
        
        
        static void ProcessMenuSelectionT(string selection)
        {
            string result;
            
            int custID;
            custID = int.Parse(GetInput("Please enter your customer ID: "));
            SecretConfig connStr = new SecretConfig();
            SqlConnection conn = new SqlConnection(connStr.GetConnString());
            result = "dbo.spCustomers_DisplayOrdersByID"; //customer order history
            SqlCommand cmd = new SqlCommand(result, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            //declare parameter and its data type
            param1 = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            //establish the input or output direction
            param1.Direction = ParameterDirection.Input;
            //give value to the parameter...if not the default will be used.
            param1.Value = custID;
            //open the connection and read the results           
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write(" ");
                Console.Write(reader[1].ToString());
                Console.Write(" ");
                Console.Write(reader[2].ToString());
                Console.Write(" ");
                Console.Write(reader[3].ToString());
                Console.Write(" ");
                Console.Write(reader[4].ToString());
                Console.Write(" ");
                Console.Write(reader[5].ToString());
                Console.Write(" ");
                Console.WriteLine(reader[6].ToString());
            }
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
        }
        static void ProcessMenuSelectionU(string selection)
        {
            string result;
            
            string firstName = GetInput("Please enter the customer's firstname");
            string lastName = GetInput("Please enter the customer's lastname");
            
            SecretConfig connStr = new SecretConfig();
            SqlConnection conn = new SqlConnection(connStr.GetConnString());
            result = "dbo.spCustomer_GetByFullName";//search customer by name 
            
            SqlCommand cmd = new SqlCommand(result, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            SqlParameter param2 =  new SqlParameter();
            
            param1 = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            param2 = cmd.Parameters.Add("@LastName",SqlDbType.NVarChar, 50);

            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            
            param1.Value = firstName;
            param2.Value = lastName;
            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            Console.WriteLine("Customer ID | Perferred Store | First Name | Last Name ");
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write("     ");    
                Console.Write(reader[1].ToString());
                Console.Write("            ");
                Console.Write(reader[2].ToString());
                Console.Write("      ");
                Console.WriteLine(reader[3].ToString());
                
            }
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
        }
        static void ProcessMenuSelectionR(string selection)
        {
            string result;
            //int prodQty;
            //int storeID;
            //int orderID;
            string firstName = GetInput("Please enter the customer's firstname");
            string lastName = GetInput("Please enter the customer's lastname");
            //int custID;
            //custID = int.Parse(GetInput("Please enter your customer ID: "));
            SecretConfig connStr = new SecretConfig();
            SqlConnection conn = new SqlConnection(connStr.GetConnString());
            if (selection == "t"){result = "dbo.spCustomers_DisplayOrdersByID"; }//customer order history
            else if (selection == "m"){result = "dbo.spCustomers_AddNew";}//add new customer
            else if (selection == "u")
            {
                result = "dbo.spCustomer_GetByFullName";//search customer by name
                
            }
            else if (selection == "n"){result = "dbo.spOrders_PlaceToStoreForCustomer";}//create order
            else if (selection == "r"){result = "dbo.spOrders_GetAllByStore";}//display all store orders
            else if (selection == "d"){result = "dbo.spOrders_GetDetails"; }//display order details
            else  {return;}
            SqlCommand cmd = new SqlCommand(result, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            SqlParameter param2 =  new SqlParameter();
            //SqlParameter param3 =  new SqlParameter();
            //SqlParameter param4 =  new SqlParameter();
            param1 = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            param2 = cmd.Parameters.Add("@LastName",SqlDbType.NVarChar, 50);
            //param3 = cmd.Parameters.Add("@PreferredStore",SqlDbType.NVarChar, 7);
            //param4 = cmd.Parameters.Add("@PreferredStore",SqlDbType.NVarChar, 7);

            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            //param3.Direction = ParameterDirection.Input;
            //param4.Direction = ParameterDirection.Input;

            param1.Value = firstName;
            param2.Value = lastName;
            //param3.Value = items[2];

            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            Console.WriteLine("Customer ID | Perferred Store | First Name | Last Name ");
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write("     ");    
                Console.Write(reader[1].ToString());
                Console.Write("            ");
                Console.Write(reader[2].ToString());
                Console.Write("      ");
                Console.WriteLine(reader[3].ToString());
                /*Console.Write(" ");
                Console.Write(reader[4].ToString());
                Console.Write(" ");
                Console.Write(reader[5].ToString());
                Console.Write(" ");
                Console.WriteLine(reader[6].ToString());*/
            }
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
        }
            /*using 
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
                   
                    Console.Write(row["StoreID"]);
                    Console.Write("  ");
                    Console.Write(row["Total"]);
                    Console.WriteLine();

                    }
                    //Console.ReadKey();
                }*/
        }
        static string GetInput(string message)
        {
            
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;

        }
        
    }

    
    }
