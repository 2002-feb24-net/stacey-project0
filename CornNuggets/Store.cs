using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Store
    {
        int storeID;

        static List<string> stores = new List<string>() {"Dallas","Arlington","Weston","Columbia","Tampa","Miami"};
        
        
        
        public void AddStore(string location)
        {
            stores.Add(location);
        }
        public void SearchStore(string location)
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
        public void DisplayStores()
        {
            foreach(string name in stores)
            {
                Console.WriteLine($"{name} Store");
            }
            
        }
    }
}
