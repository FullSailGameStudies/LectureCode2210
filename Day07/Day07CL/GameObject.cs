using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day07CL
{
    public class GameObject
    {
        #region Access Modifiers
        //public - all code can see it
        //private - ONLY my class can see it (default if not specified)
        //protected - my class and all my descendent classes
        #endregion

        #region Fields
        //keep the data safe!

        //uses _camelCasingNamingConvention
        //
        private int _x = 0, _y = 0;//instance fields (separate _x,_y for every instance)
        private static int _numberOfGameObjects = 0;//static field (only ONE for ALL instances)
        #endregion

        #region Properties
        //FULL PROPERTY
        //field + property
        public int X 
        { 
            //accessor (getter)
            //same as...
            //public int GetX() {return _x;}
            get { return _x; } 

            //mutator (setter)
            //same as...
            //public void SetX(int value) {_x = value;}
            set { 
                if(value >= 0 && value < Console.WindowWidth)
                    _x = value; 
            }
        }
        public int Y
        {
            //accessor (getter)
            //same as...
            //public int GetY() {return _y;}
            get { return _y; }

            //mutator (setter)
            //same as...
            //public void SetY(int value) {_y = value;}
            set
            {
                if (value >= 0 && value < Console.WindowHeight)
                    _y = value;
            }
        }

        //AUTO PROPERTY
        //only property (compiler will provide the field and the code for get/set)
        public ConsoleColor Color { get; protected set; } = ConsoleColor.DarkCyan;
        #endregion

        #region Constructors (c'tor)
        //default constructor provided by the compiler IFF you don't have your own constructor

        //a default constructor (no parameters)
        //public GameObject()
        //{

        //}

        public GameObject(int x, int y, ConsoleColor color)
        {
            _numberOfGameObjects++;
            X = x; //assign the parameter to the property/field
            Y = y;
            Color = color;
            //x = X;//WRONG!! backwards
        }
        #endregion

        #region Methods
        //an INSTANCE method (non-static)
        //instance methods have a hidden parameter called 'this'
        //'this' is the instance that the method was called on
        public virtual void Render()
        {
            Console.SetCursorPosition(this.X, Y);
            Console.BackgroundColor = Color;
            Console.Write(" ");
            Console.ResetColor();
        }

        public virtual bool Update()
        {
            return false;
        }

        //there is no 'this' parameter in static methods
        public static void ObjectInfo()
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine($"Number of game objects: {_numberOfGameObjects}");
        }
        #endregion
    }
}
