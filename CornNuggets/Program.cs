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
            //Core functionality
            //1. add new Customer options: a --> m
            //2. display all order history of a customer options --> t
            //3. Search customers by name --> u
            //4. place orders to store locations for customers --> n
            //5. display all order history of a store --> r
            //6. display details of an order --> d

        static void Main(string[] args)
        {
            //set up the connection to the sql server
            SecretConfig connStr = new SecretConfig();
  

            //call start menu for add/search/view/exit options
            Menu start = new Menu();
            Customer patron = new Customer();
            Store location = new Store();
            Order items = new Order();

            //essential parameters
            string fname;
            string lname;
                        

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
                else if (option == "m")
                {
                    
                    string firstName = start.GetInput("Enter the new customer's first name");
                    string lastName = start.GetInput("Enter the new customer's first name");
                    start.ShowStores();
                    string storeName = start.GetInput("Enter the new customer's perferred store name");
                    
                    patron.AddCustomer(firstName, lastName, storeName);
                }
                else if (option == "u"){ProcessMenuSelectionU(option);}
                else if (option == "r"){ProcessMenuSelectionR(option);}
                else if (option == "d"){ProcessMenuSelectionD(option);}
                else if (option == "n"){ProcessMenuSelectionN(option);}
            }while(option!="e");
            
            Environment.Exit(0);

        //start of processing selections           
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
            Console.WriteLine("");
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
                Console.Write("      ");
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
            int storeID;
                        
            SecretConfig connStr = new SecretConfig();
            SqlConnection conn = new SqlConnection(connStr.GetConnString());
            
            storeID = int.Parse(GetInput("Please enter the store number"));
            result = "dbo.spOrders_GetAllByStore";

            //display all store orders
            
            SqlCommand cmd = new SqlCommand(result, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
                        
            param1 = cmd.Parameters.Add("@StoreID", SqlDbType.Int);
            
            param1.Direction = ParameterDirection.Input;
            
            param1.Value = storeID;
                        
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            Console.WriteLine("Order ID | Date/Time Stamp | Customer ID | Total ");
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write("     ");    
                Console.Write(reader[1].ToString());
                Console.Write("      ");
                Console.Write(reader[2].ToString());
                Console.Write("      ");
                Console.WriteLine(reader[3].ToString());
                Console.WriteLine("      ");
                
            }
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
        }
        static void ProcessMenuSelectionD(string selection)
        {
            string result;
            
            int orderID;
            
            orderID = int.Parse(GetInput("Please enter the order number"));
            
            SecretConfig connStr = new SecretConfig();
            SqlConnection conn = new SqlConnection(connStr.GetConnString());
            if (selection == "t"){result = "dbo.spCustomers_DisplayOrdersByID"; }//customer order history
            else if (selection == "m"){result = "dbo.spCustomers_AddNew";}//add new customer
            else if (selection == "u")
            {
                result = "dbo.spCustomer_GetByFullName";//search customer by name
                
            }
            else if (selection == "n"){result = "dbo.spOrders_PlaceToStoreForCustomer";}//create order
            else if (selection == "r")
            {
                orderID = int.Parse(GetInput("Please enter the store number"));
                result = "dbo.spOrders_GetAllByStore";

            }//display all store orders
            else if (selection == "d"){result = "dbo.spOrders_GetDetails"; }//display order details
            else  {return;}
            SqlCommand cmd = new SqlCommand(result, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            
            param1 = cmd.Parameters.Add("@orderID", SqlDbType.Int);
            

            param1.Direction = ParameterDirection.Input;
            
            param1.Value = orderID;
                        
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            Console.WriteLine("Order ID |  SubTotal | Prod ID | Date/Time Stamp ");
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write("     ");    
                Console.Write(reader[1].ToString());
                Console.Write("      ");
                Console.Write(reader[2].ToString());
                Console.Write("      ");
                Console.WriteLine(reader[3].ToString());
                Console.WriteLine("     ");
                
            }
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
        }
        //create an order
        static int ProcessMenuSelectionN(string selection)
        {
            string result;
            int prodQty;
            int prodID;
            Menu pick = new Menu();

            string firstName = GetInput("Please enter the customer's firstname");
            string lastName = GetInput("Please enter the customer's lastname");
            pick.ShowProductMenu();
            prodID = int.Parse(GetInput("Please enter the product number of the item you want."));
            prodQty = int.Parse(GetInput("How many do you want (0 to quit)? "));
            
            SecretConfig connStr = new SecretConfig();
            SqlConnection conn = new SqlConnection(connStr.GetConnString());
           
            result = "dbo.spOrders_PlaceToStoreForCustomer";            
            
            SqlCommand cmd = new SqlCommand(result, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            SqlParameter param2 =  new SqlParameter();
            SqlParameter param3 =  new SqlParameter();
            SqlParameter param4 =  new SqlParameter();
            param1 = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            param2 = cmd.Parameters.Add("@LastName",SqlDbType.NVarChar, 50);
            param3 = cmd.Parameters.Add("@ProductID",SqlDbType.Int);
            param4 = cmd.Parameters.Add("@ProductQty",SqlDbType.Int);

            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            param3.Direction = ParameterDirection.Input;
            param4.Direction = ParameterDirection.Input;

            param1.Value = firstName;
            param2.Value = lastName;
            param3.Value = prodID;
            param4.Value = prodID;
            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            //Console.WriteLine("Order ID | Date/Time Stamp | Store ID | Customer ID | Total ");
            while (reader.Read())
            {/**/
                Console.Write(reader[0].ToString());
                Console.Write("     ");    
                Console.Write(reader[1].ToString());
                Console.Write("      ");
                Console.Write(reader[2].ToString());
                Console.Write("      ");
                Console.WriteLine(reader[3].ToString());
                //Console.WriteLine("      ");
                //Console.Write(reader[4].ToString());
                //Console.WriteLine("      ");
                //Console.WriteLine(reader[5].ToString());
                /*Console.Write(" ");
                Console.WriteLine(reader[6].ToString());*/
            }
            //int orderID=int.Parse(reader[0].ToString());
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
            //selection = GetInput("Have more to buy? [y]");
            if (selection == "y")
            {
                return 0;
            }
            return 0;
        }
        static int ProcessMenuSelectionY(int orderNum)
        {
            int prodQty;
            int prodID;
            Menu pick = new Menu();

            pick.ShowProductMenu();
            prodID = int.Parse(GetInput("Please enter the product number of the item you want."));
            prodQty = int.Parse(GetInput("How many do you want (0 to quit)? "));
            
            SecretConfig connStr = new SecretConfig();
            SqlConnection conn = new SqlConnection(connStr.GetConnString());
            
            string  result2 = "dbo.spOrders_AddToOrder";

            SqlCommand cmd = new SqlCommand(result2, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            SqlParameter param2 =  new SqlParameter();
            SqlParameter param3 =  new SqlParameter();
            param1 = cmd.Parameters.Add("@orderID", SqlDbType.Int);
            param2 = cmd.Parameters.Add("@ProductID",SqlDbType.Int);
            param3 = cmd.Parameters.Add("@ProductQty",SqlDbType.Int);

            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            param3.Direction = ParameterDirection.Input;

            param1.Value = orderNum;
            param2.Value = prodID;
            param3.Value = prodQty;
            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            Console.WriteLine("Order ID | Date/Time Stamp | Store ID | Customer ID |");
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write("     ");    
                Console.Write(reader[1].ToString());
                Console.Write("      ");
                Console.Write(reader[2].ToString());
                Console.Write("      ");
                Console.WriteLine(reader[3].ToString());
                Console.WriteLine("      ");
                Console.Write(reader[4].ToString());
                //Console.WriteLine("      ");
                /*Console.WriteLine(reader[5].ToString());
                /*Console.Write(" ");
                Console.WriteLine(reader[6].ToString());*/
            }
            int orderID=int.Parse(reader[0].ToString());
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
            string selection = GetInput("Have more to buy? [y]");
            if (selection == "y")
            {
                ProcessMenuSelectionY(orderID);
            }
            else if (prodQty==0)
            {
                return 0;
            }
            return orderID;
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
