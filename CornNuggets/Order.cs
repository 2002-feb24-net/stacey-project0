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

        public int ordID = 1000;
            public DateTime timeStamp;
            public Store storeName = new Store();
            public Customer custName = new Customer();
            public Product items = new Product("Demo", 100, 1.0);
            public double Total { get; set; }
        
        


        public Order()
        {
            timeStamp = DateTime.Now;

            
        }
        
        public int TakeOrder(string cust, string store, int prod)
        {
            timeStamp = DateTime.Now;
            ordID++;
            items.BuyProduct(prod);
            storeName.Name = store;
            custName.CustName = cust;
            Total += items.Price;
            return ordID;
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
            Console.WriteLine($"{timeStamp}, {ordID}, {storeName.Name}, {custName.CustName}, {Total}");

        }
    }
}
