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
            #region Writing CSV
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
            #endregion

            #region Reading CSV
            ReadFile(filePath);
            #endregion
        }

        private static void ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                //1. open the file in read mode
                //using (StreamReader sr = new StreamReader(filePath))
                {
                    //string line;
                    //while((line = sr.ReadLine()) != null)

                    //don't need a using statement if using File.ReadAllText
                    string line = File.ReadAllText(filePath);//open,read,close the file
                    {
                        Console.WriteLine(line);
                        string[] data = line.Split('$');
                        string name = data[0];
                        int num = int.Parse(data[1]);
                        double dNum = double.Parse(data[2]);
                        bool isGood = bool.Parse(data[3]);

                        Console.WriteLine(name);
                        Console.WriteLine(num);
                        Console.WriteLine(dNum);
                        Console.WriteLine(isGood);
                    }
                }
            }
            else
                Console.WriteLine($"{filePath} does not exists!!");
        }
    }
}
