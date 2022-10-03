using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //class variables have a default value of null
            //creating an instance of List

            //TWO ways to add items:
            //1) declaration
            List<string> menu = new List<string>();// { "Coffee", "Carmel Machiato", "Hot Chocolate" };

            Info(menu);//Count: 0  Capacity: 0
            //2) with the Add method
            menu.Add("Pumpkin Spice Latte");//adds to the end of the list
            menu.Add("Earl Grey Tea");
            Info(menu);//Count: 2  Capacity: ?

            //looping over the list
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i]);
            }

            menu.Add("Coffee");//adds to the end of the list
            menu.Add("Carmel Machiato");//Count: 4  Capacity: 4
            menu.Add("Hot Chocolate");//Count: 5  Capacity: 8
            Info(menu);//Count: 5  Capacity: ?

            //CHALLENGE 01:
            //create a list of doubles to hold the prices of your menu items
            //create a method to print the menu items and their prices

            List<double> prices = new List<double>();
            prices.Add(6.99);
            prices.Add(3.99);
            prices.Add(2.99);
            prices.Add(5.99);
            prices.Add(4.99);
            PrintMenu(menu, prices);
        }

        private static void PrintMenu(List<string> menuItems, List<double> itemPrices)
        {
            Console.Clear();
            Console.WriteLine("------Full Sail Brews-------");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{itemPrices[i],6:C2} {menuItems[i]}");
            }
        }

        static void Info(List<string> myList)
        {
            //Count: # of items that have been added
            //Capacity: length of the internal array

            //$ - interpolated string
            Console.WriteLine($"Count: {myList.Count}\tCapacity: {myList.Capacity}");
        }
    }
}
