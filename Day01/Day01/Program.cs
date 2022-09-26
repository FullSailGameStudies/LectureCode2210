using System;

namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Gotham! I am the hero you need.");

            int x1 = 0;
            int y1 = 0;
            for (int i = 0; i < 20; i++)
            {
                RandomPosition(ref x1, ref y1);
                DrawBlock(x1, y1);
            }
            DrawBlock(10, 25);
            DrawBlock(x1 + 2, y1 - 3);

            int sum = 0;
            int factor = Factor(3,ref sum);
            Console.WriteLine($"3 * {factor} = {sum}");
            Console.ReadKey();
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

        static int Factor(int num,ref int result)
        {
            int factor = 3;// random.Next(10);
            result = num * factor;
            return factor;
        }
        //
        // Modify DrawBlock and give it 2 parameters: x,y
        // use those values instead of the hardcoded values
        //
        static void DrawBlock(int x, int y)
        {
            //int x = Console.WindowWidth / 2;
            //int y = Console.WindowHeight / 2;

            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            Console.Write("     ");

            Console.ResetColor();
        }

    }
}
