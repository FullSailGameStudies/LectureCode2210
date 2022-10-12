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

        //public Player() {}  default constructor

        //my player constructor must call the base constructor to build the GameObject
        public Player(char symbol, int score, int xPos, int yPos, ConsoleColor clr) : base(xPos, yPos, clr)
        {
            Symbol = symbol;
            Score = score;
        }
    }
}
