using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Order
    {
        
            public int ordID = 1000;
            public DateTime timeStamp;
            public Store storeName = new Store();
            public Customer custName = new Customer();
            public Product items = new Product("Demo");
            double total;
        
        


        public Order()
        {
            timeStamp = DateTime.Now;
            
        }
        
        public int TakeOrder(string cust, string store, int prod)
        {
            timeStamp = DateTime.Now;
            ordID++;
            custName.AddCustomer(cust);
            storeName.AddStore(store);
            items.BuyProduct(prod);

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
            Console.WriteLine($"{timeStamp}, {ordID}, {storeName}, {custName}, {total}");

        }
    }
}
