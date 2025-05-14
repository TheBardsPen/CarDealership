using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CarDealership.Interfaces;

namespace CarDealership
{
    public class CarsDB<T> where T : ICar, IStorable
    {
        // Set directory and filename
        private const string dir = @"C:\C#\Files\AngelMay_ShaneHubbard_CalvinBorgaard\";
        private const string file = "Cars.txt";

        public static List<T> LoadCars()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // Get save file and initialize list
            StreamReader text = new StreamReader(new FileStream(dir + file, FileMode.OpenOrCreate, FileAccess.Read));
            List<T> cars = new List<T>();

            while (text.Peek() != -1)
            {
                // Break down file into rows and columns
                string row = text.ReadLine();
                string[] columns = row.Split('|');

                if (columns.Length < 7)
                    continue;

                // Switch to pull what Make (subclass) to create
                ICar c;
                switch (columns[0])
                {
                    case "Dodge":
                        c = new Dodge(
                            columns[0],
                            columns[1],
                            columns[2],
                            Convert.ToInt32(columns[3]),
                            Convert.ToInt32(columns[4]),
                            columns[5],
                            DateTime.Parse(columns[6]));
                        break;
                    case "Ford":
                        c = new Ford(
                            columns[0],
                            columns[1],
                            columns[2],
                            Convert.ToInt32(columns[3]),
                            Convert.ToInt32(columns[4]),
                            columns[5],
                            DateTime.Parse(columns[6]));
                        break;
                    case "Toyota":
                        c = new Toyota(
                            columns[0],
                            columns[1],
                            columns[2],
                            Convert.ToInt32(columns[3]),
                            Convert.ToInt32(columns[4]),
                            Convert.ToInt32(columns[5]),
                            DateTime.Parse(columns[6]));
                        break;
                    case "Nissan":
                        c = new Nissan(
                            columns[0],
                            columns[1],
                            columns[2],
                            Convert.ToInt32(columns[3]),
                            Convert.ToInt32(columns[4]),
                            columns[5],
                            DateTime.Parse(columns[6]));
                        break;
                    default:
                        continue;
                }
                cars.Add((T)c);
            }
            text.Close();

            return cars;
        }

        public static void SaveCars(List<T> cars)
        {
            StreamWriter text = new StreamWriter(new FileStream(dir + file, FileMode.Create, FileAccess.Write));

            // Write each property of each car to stream
            // Should be in same order as constructor for ease of loading

            foreach(T car in cars)
            {
                text.WriteLine(car.ToDataString("|"));
            }
            text.Close();
        }
    }
}
