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
            List<string> menu = new List<string>(10);// { "Coffee", "Carmel Machiato", "Hot Chocolate" };

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
            
            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }

            menu.Add("Coffee");//adds to the end of the list
            menu.Add("Carmel Machiato");//Count: 4  Capacity: 4
            menu.Add("Hot Chocolate");//Count: 5  Capacity: 8
            Info(menu);//Count: 5  Capacity: 8
            //menu[6] = "Dr. Pepper";

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

            // REMOVING
            // shifts all the items to the right down by 1 spot
            // 2 main ways: 
            // 1) Remove(item) -- removes the first "item" it finds
            // 2) RemoveAt(index) -- removes the item at the index
            //
            List<string> menu2 = CloneMe(menu);
            for (int i = 0; i < menu2.Count; i++)
            {
                if (menu2[i].StartsWith('C'))
                {
                    menu2.RemoveAt(i);
                    i--;
                }
            }
            //OR
            for (int i = menu2.Count - 1; i >= 0; i--)
            {
                if (menu2[i].StartsWith('C'))
                {
                    menu2.RemoveAt(i);
                }
            }
            Console.Clear();
            PrintMenu(menu, prices);
            PrintMenu(menu2, prices);

            string csvMenu = string.Empty;
            char delimiter = ';';
            char delimiter2 = '^';

            foreach (var item in menu)
            {
                csvMenu += delimiter2;
                csvMenu += item;
                csvMenu += delimiter;
            }
            Console.WriteLine(csvMenu);

            //split the string to get the data

            char[] delims = new char[] { delimiter, delimiter2 };
            string[] menuItems = csvMenu.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            foreach (var item in menuItems)
            {
                Console.WriteLine($"{++index}. {item}");
            }
        }

        private static List<string> CloneMe(List<string> menu)
        {
            //3 ways to clone a list

            //1) ToList
            List<string> clone = menu.ToList();//requires using System.Linq;

            //2) pass the list to the constructor
            clone = new List<string>(menu);

            //3) copy each item in a loop

            return clone;
        }

        private static void PrintMenu(List<string> menuItems, List<double> itemPrices)
        {
            Console.WriteLine("------Full Sail Brews-------");
            for (int i = 0; i < menuItems.Count; i++)
            {
                //,6 -- right aligns inside of 6 spaces
                //:C2 -- currency format with 2 decimal places
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
