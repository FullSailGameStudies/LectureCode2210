using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Treasure : GameObject
    {
        public Treasure(int value, int x, int y, ConsoleColor color) : base(x,y,color)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
