using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //KEYS must be unique!

            //THREE ways to add data
            //1) declaration
            Dictionary<string, double> coffeeShop = new Dictionary<string, double>()
            {
                //{ key, value }
                { "Coffee", 2.99 },
                { "Black Tea", 2.99 }
            };

            //2) Add(key,value)
            coffeeShop.Add("Pumpkin Spice Latte", 6.99);
            try
            {
                coffeeShop.Add("Pumpkin Spice Latte", 7.99);//will throw an exception!!
            }
            catch (Exception)
            {
            }

            //3) [key] = value
            coffeeShop["Shamrock Shake"] = 5.99;
            coffeeShop["Shamrock Shake"] = 6.99;//will NOT throw an exception. will overwrite the value.

            //string menuItem = "Triple Chocolate Shake";
            //double price = coffeeShop[menuItem];//will throw a key-not-found exception!
            //Console.WriteLine($"The {menuItem} costs {price:C2}.");

            //
            //dictionary challenge 01
            //create a method to print the dictionary
            //
            Console.WriteLine("------Full Sail Brews-------");
            foreach (KeyValuePair<string, double> menuItem in coffeeShop)
            {
                string name = menuItem.Key;
                double price = menuItem.Value;
                Console.WriteLine($"{price,6:C2} {name}");
            }
        }
    }
}
