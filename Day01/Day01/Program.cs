using System;

namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Gotham! I am the hero you need.");

            int x1 = Console.WindowWidth / 2;
            int y1 = Console.WindowHeight / 2;
            DrawBlock(x1, y1);
            DrawBlock(10, 25);
            DrawBlock(x1 + 2, y1 - 3);

            int sum = 0;
            int factor = Factor(3,ref sum);
            Console.WriteLine($"3 * {factor} = {sum}");
            Console.ReadKey();
        }

        // create a method to randomly generate x,y
        // use ref parameters to return the x,y

        static int Factor(int num,ref int result)
        {
            Random random = new Random();
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
