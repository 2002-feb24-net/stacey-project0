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
    class Order
    {
        /*Stacey Joseph, Revature, Project 0
         * Store Implementation
         * C:\Revature\stacey-project0\CornNuggets\Order.cs
        */
        SecretConfig connStr = new SecretConfig();
        private int ordID = 1000;
        private DateTime timeStamp;
        private Store storeName = new Store();
        private Customer custLName = new Customer();
        private Customer custFName = new Customer();
        private int ordQty;
        public double Total { get; set; }
        public int OrdID { get => ordID; set => ordID = value; }
        public int OrdQty { get => ordQty; set => ordQty = value;}
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        internal Store StoreName { get => storeName; set => storeName = value; }
        internal Customer CustLName { get => custLName; set => custLName = value; }
        internal Customer CustFName { get => custFName; set => custFName = value; }

        public Order()
        {
            TimeStamp = DateTime.Now;

            
        }
        
        public void CreateOrder(string custfirst, string custlast, int prod, int qty)
        {
            
        }
        public void AddToOrder(string custfirst, string custlast, int prod, int qty)
        {
            
        }
        public void SearchOrder(int id)
        {
            /*if (name.Contains(id))
            {
                Console.WriteLine("No match found!");
            }
            else
            {
                Console.WriteLine("Order Found");
            }*/

        }
        public void DisplayOrder(int orderNum)
        {
            SecretConfig connStr = new SecretConfig();
                SqlConnection conn = new SqlConnection(connStr.GetConnString());
            
            
                SqlCommand cmd = new SqlCommand("dbo.spCustomers_AddNew", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 =  new SqlParameter();
                param1 = cmd.Parameters.Add("@OrderID", SqlDbType.Int);

                param1.Direction = ParameterDirection.Input;

                param1.Value = orderNum;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader[0].ToString());
                    Console.Write(" ");
                    //Console.WriteLine(reader[1].ToString());
                }
                //Console.Read();
                Console.WriteLine("Transaction Completed Successfully!");
                //Close reader and connection
                reader.Close();
                conn.Close();
            /*
            using 
            (SqlDataAdapter sqlda = new SqlDataAdapter("dbo.spOrders_GetDetails", connStr.GetConnString()))
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

        internal void DisplayCustomerOrders(int custID, string pstore)
        {
            if (pstore.Length==7)
            {
                // "dbo.spCustomers_DisplayOrdersByID"
                SecretConfig connStr = new SecretConfig();
                SqlConnection conn = new SqlConnection(connStr.GetConnString());
            
            
                SqlCommand cmd = new SqlCommand("dbo.spCustomers_AddNew", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 =  new SqlParameter();
                SqlParameter param2 =  new SqlParameter();
                param1 = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                param2 = cmd.Parameters.Add("@PreferredStore",SqlDbType.NVarChar, 7);

                param1.Direction = ParameterDirection.Input;
                param2.Direction = ParameterDirection.Input;

                param1.Value = custID;
                param2.Value = pstore;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader[0].ToString());
                    Console.Write(" ");
                    Console.WriteLine(reader[1].ToString());
                }
                //Console.Read();
                Console.WriteLine("Transaction Completed Successfully!");
                //Close reader and connection
                reader.Close();
                conn.Close();

                using 
                    (SqlDataAdapter sqlda = new SqlDataAdapter("dbo.spOrders_GetAllByStore 1", connStr.GetConnString()))
                    {
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    foreach(DataRow row in dtbl.Rows)
                    {
                    Console.Write(row["OrderID"]);
                    Console.Write("  ");
                    Console.Write(row["DateTimeStamp"]);
                    Console.Write("  ");
                    Console.Write(row["ProductID"]);
                    Console.Write("  ");
                    Console.Write(row["StoreID"]);
                    Console.Write("  ");
                    Console.Write(row["Total"]);
                    Console.WriteLine();
                    }
                    //Console.ReadKey();
                }
            }
            
        }
    }
}
