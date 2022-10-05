using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04
{
    enum Superpower
    {
        Speed, Money, Strength, Flying, Invisibility, Telekenisis, Swimming
    }
    class Superhero
    {
        public string Name { get; set; }
        public string Secret { get; set; }
        public Superpower Power { get; set; }
        public int Level { get; set; }
    }

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

            List<Superhero> supers = new List<Superhero>();
            supers.Add(new Superhero() { Name = "Batman", Secret = "Bruce Wayne", Power = Superpower.Money, Level = 50 });
            supers.Add(new Superhero() { Name = "Superman", Secret = "Clark Kent", Power = Superpower.Flying, Level = 10 });
            supers.Add(new Superhero() { Name = "Flash", Secret = "Barry Allen", Power = Superpower.Speed, Level = 25 });
            supers.Add(new Superhero() { Name = "Aquaman", Secret = "Fish Guy", Power = Superpower.Swimming, Level = 30 });
            supers.Add(new Superhero() { Name = "Wonder Woman", Secret = "Diana Prince", Power = Superpower.Strength, Level = 40 });

            Serialize(supers, filePath);
            List<Superhero> JLA = Deserialize(filePath);

            foreach (var super in JLA)
            {
                Console.WriteLine($"Hello citizen. I am {super.Name} (aka {super.Secret}). I am good at {super.Power}!");
            }
        }

        private static List<Superhero> Deserialize(string filePath)
        {
            List<Superhero> supers = null;
            filePath = Path.ChangeExtension(filePath, ".json");
            if (File.Exists(filePath))
            {
                string jsonText = File.ReadAllText(filePath);
                //jsonText = "Steev";
                Console.WriteLine(jsonText);

                //deserialize the text into objects
                try
                {
                    supers = JsonConvert.DeserializeObject<List<Superhero>>(jsonText);
                }
                catch (Exception ex)
                {
                }
            }
            return supers;
        }

        private static void Serialize(List<Superhero> supers, string filePath)
        {
            filePath = Path.ChangeExtension(filePath, ".json");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                using (JsonTextWriter jtw = new JsonTextWriter(sw))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(jtw, supers);
                }
            }
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
