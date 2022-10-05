using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Open the file in write mode
            string filePath = @"C:\temp\2210\data.csv";
            char delimiter = '$';
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                //2. Write to the file
                sw.Write("Batman");
                sw.Write(delimiter);
                sw.Write(5);
                sw.Write(delimiter);
                sw.Write(13.7);
                sw.Write(delimiter);
                sw.Write(true);
            }//3. CLOSES THE FILE!!

        }
    }
}
