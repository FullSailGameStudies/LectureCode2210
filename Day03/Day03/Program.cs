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
            Print(coffeeShop);

            string item = "Pumpkin Spice Latte";
            ShowPrice(coffeeShop, item);
            Remove(coffeeShop, item);

            item = "Herbal tea";
            Remove(coffeeShop, item);

            ShowPrice(coffeeShop, item);

            DictionaryChallenge();
        }

        private static void DictionaryChallenge()
        {
            List<string> students = new List<string>()
            { "Jacob", "Christopher", "John", "Wolf", "Charlie", "Michael", "Frankie", "Miroslav", "Brandon", "Conor", "Devasean", "Eryn"};

            Random randy = new Random();
            Dictionary<string, double> pg2 = new Dictionary<string, double>();
            foreach (var student in students)
            {
                pg2.Add(student, randy.NextDouble() * 100);
            }

            Console.WriteLine("---------PG2 GRADES: October------------");
            foreach (KeyValuePair<string,double> grade in pg2)
            {
                if (grade.Value < 59.5) Console.BackgroundColor = ConsoleColor.Red;
                else if(grade.Value < 69.5) Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (grade.Value < 79.5) Console.ForegroundColor = ConsoleColor.Yellow;
                else if (grade.Value < 89.5) Console.ForegroundColor = ConsoleColor.Blue;
                else Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{grade.Value,7:N2} ");

                Console.ResetColor();
                Console.WriteLine($"{grade.Key} ");
            }
        }

        private static void ShowPrice(Dictionary<string, double> coffeeShop, string item)
        {
            if (coffeeShop.TryGetValue(item, out double price))
            {
                //double price = coffeeShop[item];
                coffeeShop[item] = price * 1.2;//overwrite the old value
                Console.WriteLine($"{item} was {price:C2}. Now it's {coffeeShop[item]:C2}. THanks Putin!");
            }
            else
                Console.WriteLine($"{item} was NOT found.");
        }

        private static void Remove(Dictionary<string, double> coffeeShop, string item)
        {
            bool removed = coffeeShop.Remove(item);
            if (removed)
                Console.WriteLine($"{item} was removed.");
            else
                Console.WriteLine($"{item} was NOT found.");
        }

        static void Print(Dictionary<string, double> menu)
        {
            Console.WriteLine("------Full Sail Brews-------");
            foreach (KeyValuePair<string, double> menuItem in menu)
            {
                string name = menuItem.Key;
                double price = menuItem.Value;
                Console.WriteLine($"{price,6:C2} {name}");
            }
        }
    }
}
