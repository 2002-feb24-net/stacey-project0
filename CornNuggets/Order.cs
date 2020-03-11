using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Order
    {
        
            public int ordID;
            public DateTime timeStamp;
            public Store storeName;
            public Customer custName;
            public List<Product> prod = new List<Product>();
            double total;
        
        


        public Order()
        {
            timeStamp = DateTime.Now;
            
        }
        
        public int TakeOrder(string cust, string store, int prod)
        {
            timeStamp = DateTime.Now;
            custName.AddCustomer(cust);
            storeName.AddStore(store);
            //prod.AddProduct(prod);

            return ordID++;
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
            Console.WriteLine($"{timeStamp}, {ordID}, {storeName}, {custName}, {total}");

        }
    }
}
