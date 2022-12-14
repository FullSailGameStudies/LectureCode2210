using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public static class Factory
    {
        static Random randy = new Random();

        public static GameObject BuildSeeker(Player player)
        {
            int xPos = randy.Next(Console.WindowWidth);
            int yPos = randy.Next(Console.WindowHeight);
            ConsoleColor clr = GetColor();
            return new Seeker(player, xPos, yPos, clr);
        }
        public static GameObject BuildGameObject()
        {
            int xPos = randy.Next(Console.WindowWidth);
            int yPos = randy.Next(Console.WindowHeight);
            ConsoleColor clr = GetColor();
            return new GameObject(xPos, yPos, clr);
        }
        public static GameObject BuildGameObject(int xPos, int yPos, ConsoleColor clr)
        {
            return new GameObject(xPos, yPos, clr);
        }

        public static GameObject BuildTreasure()
        {
            int xPos = randy.Next(Console.WindowWidth);
            int yPos = randy.Next(Console.WindowHeight);
            return new Treasure(randy.Next(1000), xPos, yPos, ConsoleColor.Yellow);
        }

        public static FantasyWeapon MakeWeapon(WeaponRarity rarity, int level, int maxDamage, int cost)
        {
            return new FantasyWeapon(rarity, level, maxDamage, cost);
        }


        public static ConsoleColor GetColor()
        {
            ConsoleColor color;
            while ((color = (ConsoleColor)randy.Next(16)) == ConsoleColor.Black) ;
            Debug.WriteLine(color);
            return color;
        }
    }
}
