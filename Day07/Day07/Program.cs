
using Day07CL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Day07
{
    internal class Program
    {
        static Random randy = new Random();
        static void Main(string[] args)
        {
            int num = 5;//4 bytes
            long bigNum = num;//8 bytes. implicit casting
            num = (int)bigNum;//explicit casting
            //num = (int)"5";


            Inventory backpack = new Inventory(3, new List<FantasyWeapon>());
            //backpack.AddItem("map");
            //backpack.AddItem("shovel");
            //backpack.AddItem("sword");
            //try
            //{
            //    backpack.AddItem("pipe bomb");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.ReadKey();

            FantasyWeapon sting = new FantasyWeapon(WeaponRarity.Legendary, 100, 1000, 100000);
            int damage = sting.DoDamage();
            Console.WriteLine($"Dora swings sting and does {damage} damage to the rat.");
            backpack.AddItem(sting);
            backpack.AddItem(new BowWeapon(5, 10, WeaponRarity.Common, 1, 10, 10));
            backpack.PrintInventory();
            Console.ReadKey();

            Player player;//null
            int xPos = Console.WindowWidth/2;
            int yPos = Console.WindowHeight/2;
            ConsoleColor clr = ConsoleColor.DarkCyan;

            player = new Player('$', 0, xPos, yPos, clr);//create an instance of GameObject

            //
            // UPCASTING
            // going from a DERIVED type (Player) to a BASE type (GameObject)
            // ALWAYS SAFE!
            GameObject p1 = player;

            p1 = new GameObject(6, 4, ConsoleColor.DarkYellow);

            //
            // DOWNCASING
            //going from a BASE type (GameObject) to a DERIVED type (Player)
            // NOT SAFE!!!!!!!
            // ways to "safely" downcast
            // 1. try-catch with explicit cast
            try
            {
                Player p2 = (Player)p1;
            }
            catch (Exception)
            {
            }
            //2. use the 'as' keyword
            //   if it CANNOT be downcasted, NULL will be used
            Player p3 = p1 as Player;
            if(p3 != null)
                Console.WriteLine(p3.X);

            //3. use the pattern matching
            if(p1 is Player p4)
                Console.WriteLine(p4.X);


            List<GameObject> gameObjects = new List<GameObject>();
            for (int i = 0; i < 20; i++)
            {
                //xPos = randy.Next(Console.WindowWidth);
                //yPos = randy.Next(Console.WindowHeight);
                Debug.Write(i);
                //clr = GetColor();
                gameObjects.Add(Factory.BuildGameObject());
            }
            for (int i = 0; i < 5; i++)
            {
                gameObjects.Add(Factory.BuildTreasure());
            }
            gameObjects.Add(player);

            Console.Clear();
            while (!_isOver)
            {
                Update(gameObjects);
                Render(gameObjects);
                //GameObject.ObjectInfo();
                Collision(player, gameObjects);
                if(!_isOver) HUD(player);
            }
            //player.Render();//player is passed in as the 'this'
            ////DrawGameObject(player);
            //int index = 0;
            //foreach (var gObj in gameObjects)
            //{
            //    gObj.Render(); //gObj is passed in as the 'this' parameter
            //    //DrawGameObject(gObj);
            //    Console.Write(index++);
            //}
            //player.X = Console.WindowWidth / 2;//call the set on the property
            //int x = player.X; //calls the get on the property

            Console.ReadKey();

        }

        private static void HUD(Player player)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player 1  Score: {player.Score}  Health: {player.Health}");
        }

        private static void Collision(Player player, List<GameObject> gameObjects)
        {
            for (int i = gameObjects.Count - 1; i >= 0; i--)
            {
                GameObject item = gameObjects[i];
                if (player != item)
                {
                    if(player.X == item.X && player.Y == item.Y)
                    {
                        if (item is Treasure pickUp)
                        {
                            player.Score += pickUp.Value;
                            gameObjects.RemoveAt(i);//remove the treasure
                        }
                        else
                        {
                            player.Health -= 10;
                            if (player.Health <= 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Game over man!");
                                Console.ResetColor();
                                _isOver = true;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private static void Render(List<GameObject> gameObjects)
        {
            Console.Clear();
            foreach (var item in gameObjects)
            {
                item.Render();
            }
        }

        static bool _isOver = false;
        private static void Update(List<GameObject> gameObjects)
        {
            foreach (var item in gameObjects)
            {
                if (item is Player player)
                    _isOver = player.Update();
            }
        }

        private static void DrawGameObject(GameObject gObject)
        {
            Console.SetCursorPosition(gObject.X, gObject.Y);
            Console.BackgroundColor = gObject.Color;
            Console.Write(" ");
            Console.ResetColor();
        }

    }
}
