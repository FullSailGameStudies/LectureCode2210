using System.Dynamic;

namespace GroupChat02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu = new string[] { "1. Play", "2. Exit" };

            List<string> menuList = menu.ToList();
            menuList.Sort();

            int selection = 0;
            while (selection != 2)
            {
                Console.Clear();
                Input.GetMenuChoice("Make a selection: ", menu, out selection);
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Play game");
                        break;
                }
                Console.ReadKey();
            }

            int w = Console.WindowWidth;
            int h = Console.WindowHeight;
            List<ConsoleColor> colors = new List<ConsoleColor>(w * h);
            for (int i = 0; i < w * h; i++)
            {
                colors.Add(GetColor());
            }
            Console.CursorVisible = false;
            Draw(w, h, colors);
            Console.ReadKey();
            colors.Sort();
            Draw(w, h, colors);
            Console.ReadKey();
        }

        private static void Draw(int w, int h, List<ConsoleColor> colors)
        {
            Console.Clear();
            int index = 0;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.BackgroundColor = colors[index++];
                    Console.Write((char)rando.Next(65,82));
                }
            }
            Console.ResetColor();
        }

        static Random rando = new Random();
        private static ConsoleColor GetColor()
        {
            return (ConsoleColor)rando.Next(16);
        }
    }

    public static class Input
    {
        public static string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static bool ValidInteger(int number, int min, int max)
        {
            return number >= min && number <= max;
        }

        public static int GetInteger(string message, int min, int max)
        {
            do
            {
                string input = GetInput(message);
                if(int.TryParse(input, out int number) && ValidInteger(number, min, max))
                    return number;

                Console.WriteLine("ERROR! That was not a valid number.");
            } while (true);
        }

        public static bool ValidString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static void GetString(string message, ref string input)
        {
            do
            {
                input = GetInput(message);
                if (ValidString(input))
                    return;

                Console.WriteLine("ERROR! That was not a valid string.");
            } while (true);
        }

        public static void GetMenuChoice(string message, string[] menuOptions, out int menuSelection)
        {
            foreach (var menuOption in menuOptions)
                Console.WriteLine(menuOption);

            menuSelection = GetInteger(message, 1, menuOptions.Length);
        }
    }
}