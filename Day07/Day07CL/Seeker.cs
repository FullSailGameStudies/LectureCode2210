using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Seeker : GameObject
    {
        Player _player;

        public Seeker(Player player, int xPos, int yPos, ConsoleColor clr) : base(xPos, yPos, clr)
        {
            _player = player;
        }
        Random randy = new Random();
        public override bool Update()
        {
            if(randy.Next(10) >= 5)
            {
                if (_player.X < X)
                    X--;
                else
                    X++;
            }
            else
            {
                if (_player.Y < Y)
                    Y--;
                else
                    Y++;
            }
            return false;
        }

        //public override void Render()
        //{
        //    //Color = ConsoleColor.Black;
        //    base.Render();
        //}
    }
}
