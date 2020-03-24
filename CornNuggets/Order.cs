using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Order
    {
        /*Stacey Joseph, Revature, Project 0
         * Store Implementation
         * C:\Revature\stacey-project0\CornNuggets\Order.cs
        */

        private int ordID = 1000;
        private DateTime timeStamp;
        private Store storeName = new Store();
        private Customer custName = new Customer();
        public Product items = new Product("Demo", 100, 1.0);
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
            OrdID++;
            items.BuyProduct(prod);
            StoreName.Name = store;
            CustName.CustName = cust;
            Total += items.Price;
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
            Console.WriteLine($"{TimeStamp}, {OrdID}, {StoreName.Name}, {CustName.CustName}, {Total}");

        }
    }
}
