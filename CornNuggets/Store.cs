using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Store
    {
        int storeID;
        public string Name { get; set; }

        static List<string> stores = new List<string>() {"Dallas","Arlington","Weston","Columbia","Tampa","Miami"};
        
        
        
        public void AddStore(string location)
        {
            //input validation before add
            if (isStore(location))
            {
                System.Console.WriteLine("Store Already Exists!");
            }
            else
            {
                //add request fulfillment
                stores.Add(location);
            }
            
        }
        public bool isStore(string location)
        {
            if (stores.Contains(location))
            {
                //Console.WriteLine("Location Found");
                return true;
            }
            else
            {
                //Console.WriteLine("No Match Found");
                return false;
            }
        }
        public void DisplayStores()
        {
            foreach(string name in stores)
            {
                //print list of all store locations
                Console.WriteLine($"{name} Store");
            }
            
        }
    }
}
