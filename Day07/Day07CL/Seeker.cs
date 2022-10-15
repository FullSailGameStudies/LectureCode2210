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
        private int _oldX, _oldY;
        Random randy = new Random();

        public Seeker(Player player, int xPos, int yPos, ConsoleColor clr) : base(xPos, yPos, clr)
        {
            _player = player;
        }

        private void SavePosition()
        {
            _oldX = X;
            _oldY = Y;
        }
        public override bool Update()
        {
            SavePosition();
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

        public override void Render()
        {
            int x = X, y = Y;
            ConsoleColor clr = Color;

            X = _oldX; Y = _oldY;
            Color = ConsoleColor.Black;
            base.Render();

            X = x; Y = y; Color = clr;
            base.Render();
        }
    }
}
