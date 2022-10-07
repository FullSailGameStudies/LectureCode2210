using System;
using System.Collections.Generic;
using System.Linq;

namespace Day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Batman", s2 = "Batmen";
            //CompareTo
            //returns an int
            //  -1   LESS THAN
            //   0   EQUAL TO
            //   1   GREATER THAN
            int compResult = s1.CompareTo(s2);
            if (compResult == 0) Console.WriteLine($"{s1} EQUALS {s2}");
            else if(compResult > 0) Console.WriteLine($"{s1} GREATER THAN {s2}");
            else if (compResult < 0) Console.WriteLine($"{s1} LESS THAN {s2}");
            Console.ReadKey();


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Random rnd = new Random();
            while (true)
            {
                if (rnd.Next(6) == 5)
                    break;
            }
            Printer(0);

            Bats(0);
            Console.ResetColor();
            Console.Write((char)66);
            Console.Write((char)65);
            Console.Write((char)84);
            Console.Write((char)77);
            Console.Write((char)65);
            Console.Write((char)78);
            Console.ReadKey();
        }

        static void Bats(int i)
        {
            if(i < 100)
            {
                Console.ForegroundColor = GetColor();
                Console.Write((char)78);
                Console.Write((char)65);
                Console.Write(' ');
                Bats(i + 1);
            }
        }
        static Random rando = new Random();
        private static ConsoleColor GetColor()
        {
            ConsoleColor color;
            while ((color = (ConsoleColor)rando.Next(16)) == ConsoleColor.Black);
            return color;
        }

        static ulong Factorial(uint N)
        {
            if (N <= 1) return 1;

            return N * Factorial(N - 1);
        }

        static void Printer(int num)
        {
            if (num < 10) //exit condition
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(num);

                Printer(num + 1);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(num);
            }
        }
    }
}
