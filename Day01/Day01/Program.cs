using System;

namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Gotham! I am the hero you need.");

            ConsoleColor backColor;
            int x1 = 0;
            int y1 = 0;
            for (int i = 0; i < 20; i++)
            {
                RandomColor(out backColor);
                RandomPosition(ref x1, ref y1);
                DrawBlock(x1, y1, backColor);
            }
            DrawBlock(10, 25);
            DrawBlock(x1 + 2, y1 - 3);

            int sum;// = 0;
            int factor = Factor(3,out sum);

            sum = Factor(4, 3);
            sum = Factor(5);
            Console.WriteLine($"3 * {factor} = {sum}");
            Console.ReadKey();
        }

        static int Factor(int num, int factor = 2)
        {
            return num * factor;
        }

        //create a method to randomly generate a color
        //use an out parameter to return the color
        //call it in DrawBlock to change the color of the block
        static void RandomColor(out ConsoleColor color)
        {
            color = (ConsoleColor) rando.Next(16);//color range is 0-15
        }

        static bool IntTryParse(string input, out int number)
        {
            bool isANumber = false;
            number = 0;
            //use try-catch to handle exceptions
            try
            {
                number = int.Parse(input);
                isANumber = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! ERROR! Not a number!");
            }
            return isANumber;
        }

        // create a method to randomly generate x,y
        // use ref parameters to return the x,y
        // call it in main to get x,y for calling DrawBlock
        static void RandomPosition(ref int x, ref int y)
        {
            //0 - (WindowWidth-1)
            x = rando.Next(Console.WindowWidth);
            y = rando.Next(Console.WindowHeight);
        }

        static Random rando = new Random();

        static int Factor(int num,out int result)
        {
            int factor = 3;// random.Next(10);
            result = num * factor;
            return factor;
        }
        //
        // Modify DrawBlock and give it 2 parameters: x,y
        // use those values instead of the hardcoded values
        //

        //add an optional color parameter
        static void DrawBlock(int x, int y, ConsoleColor color = ConsoleColor.DarkCyan)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            Console.Write("     ");
            Console.ResetColor();
        }

    }
}
