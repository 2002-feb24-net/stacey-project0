using System;
using System.Collections.Generic;


namespace CornNuggets
{
    class Program
    {
        static void Main(string[] args)
        {
            //call start menu for add/search/view/exit options
            Menu start = new Menu();
            Customer patron = new Customer();
            Store location = new Store();
            //loop through menu options until exit
            string option;
            start.ShowMainMenu();
            option = start.GetInput("Enter the letter of your choice: ");
            do
            {
                
                switch (option)
                {
                    case "a":
                    {
                        start.ShowAddMenu();
                        break;
                    }
                    case "s":
                    {
                        start.ShowSearchMenu();
                        break;
                    }
                    case "v":
                    {
                        start.ShowViewMenu();
                        break;
                    }
                }
                option = start.GetInput("Enter the letter of your choice: ");
            }while (option != "e");
            


        }
        static string GetInput(string message)
        {
            
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;

        }
    }
}
