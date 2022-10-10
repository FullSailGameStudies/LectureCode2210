
using Day07CL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day07
{
    internal class Program
    {
        static Random randy = new Random();
        static void Main(string[] args)
        {
            Inventory backpack = new Inventory(3, new List<string>());
            backpack.AddItem("map");
            backpack.AddItem("shovel");
            backpack.AddItem("sword");
            try
            {
                backpack.AddItem("pipe bomb");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

            FantasyWeapon sting = new FantasyWeapon(WeaponRarity.Legendary, 100, 1000, 100000);
            int damage = sting.DoDamage();
            Console.WriteLine($"Dora swings sting and does {damage} damage to the rat.");

            GameObject player;//null
            int xPos = randy.Next(Console.WindowWidth);
            int yPos = randy.Next(Console.WindowHeight);
            ConsoleColor clr = GetColor();

            player = new GameObject(xPos, yPos, clr);//create an instance of GameObject
            List<GameObject> gameObjects = new List<GameObject>();
            for (int i = 0; i < 20; i++)
            {
                xPos = randy.Next(Console.WindowWidth);
                yPos = randy.Next(Console.WindowHeight);
                Debug.Write(i);
                clr = GetColor();
                gameObjects.Add(new GameObject(xPos, yPos, clr));
            }
            player.Render();//player is passed in as the 'this'
            //DrawGameObject(player);
            int index = 0;
            foreach (var gObj in gameObjects)
            {
                gObj.Render(); //gObj is passed in as the 'this' parameter
                //DrawGameObject(gObj);
                Console.Write(index++);
            }
            GameObject.ObjectInfo();
            //player.X = Console.WindowWidth / 2;//call the set on the property
            //int x = player.X; //calls the get on the property

            Console.ReadKey();

        }

        private static void DrawGameObject(GameObject gObject)
        {
            Console.SetCursorPosition(gObject.X, gObject.Y);
            Console.BackgroundColor = gObject.Color;
            Console.Write(" ");
            Console.ResetColor();
        }

        private static ConsoleColor GetColor()
        {
            ConsoleColor color;
            while ((color = (ConsoleColor)randy.Next(16)) == ConsoleColor.Black) ;
            Debug.WriteLine(color);
            return color;
        }
    }
}
