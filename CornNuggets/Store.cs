using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Store
    {
        int storeID;

        static List<string> stores = new List<string>() {"Dallas","Arlington","Weston","Columbia","Tampa","Miami"};
        
        
        
        static void AddStore(string location)
        {
            stores.Add(location);
        }
        static void SearchStore(string location)
        {
            if (stores.Contains(location))
            {
                Console.WriteLine("Location Found");
            }
            else
            {
                Console.WriteLine("No Match Found");
            }
        }
        static void DisplayStores(string[] args)
        {
            Console.WriteLine("Here's your orderd!");
        }
    }
}
