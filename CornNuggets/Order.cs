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
        private Customer custName = new Customer();
        public double Total { get; set; }
        public int OrdID { get => ordID; set => ordID = value; }
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        internal Store StoreName { get => storeName; set => storeName = value; }
        internal Customer CustName { get => custName; set => custName = value; }

        public Order()
        {
            TimeStamp = DateTime.Now;

            
        }
        
        public int TakeOrder(string cust, string store, int prod)
        {
            TimeStamp = DateTime.Now;
            StoreName.Name = store;
            CustName.CustName = cust;
            return OrdID;
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
        public void DisplayOrder()
        {
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
    }
}
