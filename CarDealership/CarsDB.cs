using System;
using System.Collections.Generic;
using System.IO;

namespace CarDealership
{
    public class CarsDB
    {
        // Set directory and filename
        private const string dir = @"C:\C#\Files\AngelMay_ShaneHubbard_CalvinBorgaard\";
        private const string file = "Cars.txt";

        public static List<Car> LoadCars()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // Get save file and initialize list
            StreamReader text = new StreamReader(new FileStream(dir + file, FileMode.OpenOrCreate, FileAccess.Read));
            List<Car> cars = new List<Car>();

            while (text.Peek() != -1)
            {
                // Break down file into rows and columns
                string row = text.ReadLine();
                string[] columns = row.Split('|');

                // Switch to pull what Make (subclass) to create
                Car c;
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
                            Convert.ToDateTime(columns[6]));
                        break;
                    case "Ford":
                        c = new Ford(
                            columns[0],
                            columns[1],
                            columns[2],
                            Convert.ToInt32(columns[3]),
                            Convert.ToInt32(columns[4]),
                            columns[5],
                            Convert.ToDateTime(columns[6]));
                        break;
                    case "Toyota":
                        c = new Toyota(
                            columns[0],
                            columns[1],
                            columns[2],
                            Convert.ToInt32(columns[3]),
                            Convert.ToInt32(columns[4]),
                            Convert.ToInt32(columns[5]),
                            Convert.ToDateTime(columns[6]));
                        break;
                    case "Nissan":
                        c = new Nissan(
                            columns[0],
                            columns[1],
                            columns[2],
                            Convert.ToInt32(columns[3]),
                            Convert.ToInt32(columns[4]),
                            columns[5],
                            Convert.ToDateTime(columns[6]));
                        break;
                    default:
                        continue;
                }
                cars.Add(c);
            }
            text.Close();

            return cars;
        }

        public static void SaveCars(List<Car> cars)
        {
            StreamWriter text = new StreamWriter(new FileStream(dir + file, FileMode.Create, FileAccess.Write));

            // Write each property of each car to stream
            // Should be in same order as constructor for ease of loading
            foreach (Car c in cars)
            {
                text.Write($"{c.Make}|");
                text.Write($"{c.Model}|");
                text.Write($"{c.Color}|");
                text.Write($"{c.Year}|");
                text.Write($"{c.Price}|");

                // Switch to handle MakeSpecific properties
                string make = c.Make;
                switch (make)
                {
                    case "Dodge":
                        Dodge d = (Dodge)c;
                        text.Write($"{d.Engine}|");
                        break;
                    case "Ford":
                        Ford f = (Ford)c;
                        text.Write($"{f.Trim}|");
                        break;
                    case "Toyota":
                        Toyota t = (Toyota)c;
                        text.Write($"{t.Mileage}|");
                        break;
                    case "Nissan":
                        Nissan n = (Nissan)c;
                        text.Write($"{n.Transmission}|");
                        break;
                    default:
                        break;
                }

                text.WriteLine(c.DateAdded);
            }
            text.Close();
        }
    }
}
