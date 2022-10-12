using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Player : GameObject
    {
        public char Symbol { get; set; }
        public int Score { get; set; }
        public int Health { get; set; }

        //public Player() {}  default constructor

        //my player constructor must call the base constructor to build the GameObject
        public Player(char symbol, int score, int xPos, int yPos, ConsoleColor clr) : base(xPos, yPos, clr)
        {
            Health = 100;
            Symbol = symbol;
            Score = score;
        }

        public void MoveLeft()
        {
            if (X == 0)
                X = Console.WindowWidth - 1;
            else
                X--;
        }
        public void MoveRight()
        {
            if (X == Console.WindowWidth - 1)
                X = 0;
            else
                X++;
        }
        public void MoveUp()
        {
            if (Y == 0)
                Y = Console.WindowHeight - 1;
            else
                Y--;
        }
        public void MoveDown()
        {
            if (Y == Console.WindowHeight - 1)
                Y = 0;
            else
                Y++;
        }

        public bool Update()
        {
            bool isOver = false;
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    isOver = true;
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                default:
                    break;
            }
            return isOver;
        }
    }
}
