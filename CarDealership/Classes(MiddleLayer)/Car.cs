using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public abstract class Car
    {
        // Set public fields as read/write
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public DateTime DateAdded { get; set; }

        // Build constructor
        public Car(string make, string model, string color, int year, int price, DateTime dateAdded)
        {
            Make = make;
            Model = model;
            Color = color;
            Year = year;
            Price = price;
            DateAdded = dateAdded;
        }

        // Overrideable method to display string
        public virtual string GetDisplayText()
        {
            string display = $"\t{DateAdded.ToString()}" +
                $"{Make} - {Model}\n" +
                $"{Color}\n" +
                $"{Year}\n" +
                $"{Price.ToString("c")}";

            return display;
        }
    }
}
