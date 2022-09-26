using System;

namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Gotham! I am the hero you need.");

            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;
            DrawBlock(x, y);
            DrawBlock(10, 25);
            DrawBlock(x + 2, y - 3);
            Console.ReadKey();
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
