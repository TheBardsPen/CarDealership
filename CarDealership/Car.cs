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
        public decimal Price { get; set; }

        // Build constructor
        public Car(string make, string model, string color, int age, decimal price)
        {
            Make = make;
            Model = model;
            Color = color;
            Year = age;
            Price = price;
        }

        // Overrideable method to display string
        public virtual string GetDisplayText()
        {
            string display = $"{Make} - {Model}\n" +
                $"{Color}\n" +
                $"{Year}\n" +
                $"{Price.ToString("c")}";

            return display;
        }
    }
}
