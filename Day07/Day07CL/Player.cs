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

        private int _oldX, _oldY;

        //public Player() {}  default constructor

        //my player constructor must call the base constructor to build the GameObject
        public Player(char symbol, int score, int xPos, int yPos, ConsoleColor clr) : base(xPos, yPos, clr)
        {
            Health = 100;
            Symbol = symbol;
            Score = score;
        }

        private void SavePosition()
        {
            _oldX = X;
            _oldY = Y;
        }

        public void MoveLeft()
        {
            SavePosition();
            if (X == 0)
                X = Console.WindowWidth - 1;
            else
                X--;
        }
        public void MoveRight()
        {
            SavePosition();
            if (X == Console.WindowWidth - 1)
                X = 0;
            else
                X++;
        }
        public void MoveUp()
        {
            SavePosition();
            if (Y == 0)
                Y = Console.WindowHeight - 1;
            else
                Y--;
        }
        public void MoveDown()
        {
            SavePosition();
            if (Y == Console.WindowHeight - 1)
                Y = 0;
            else
                Y++;
        }

        public override bool Update()
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

        public override void Render()
        {
            Erase(_oldX, _oldY);
            //not calling the base means FULLY overriding
            //base.Render();//calling the base means EXTENDING the base version
            Console.SetCursorPosition(this.X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
            Console.ResetColor();
        }

        private void Erase(int oldX, int oldY)
        {
            Console.SetCursorPosition(oldX, oldY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.ResetColor();
        }
    }
}
