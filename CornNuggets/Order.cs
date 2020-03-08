using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Order
    {
        static int ordID=1000;
        DateTime timeStamp;
        Store storeNum;
        Customer custID;
        List<string> products;


        static List<int> orders = new List<int>() {ordID};
        static void AddOrder()
        {
            orders.Add(ordID++);
        }
        static void SearchOrder(int id)
        {
            if (orders.Contains(id))
            {
                Console.WriteLine("Order Found");
            }
        }
        static void DisplayOrder(string[] args)
        {
            Console.WriteLine("Here's your order!");
        }
    }
}
