using CarDealership.Interfaces;
using System;
using System.Security.Cryptography.X509Certificates;

namespace CarDealership
{
    public abstract class Car : ICar, IComparable<ICar>
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
        public abstract string GetDisplayText(string sep);
        
        public int CompareTo(ICar other)
        {
            if (other is Car car) 
                return this.Price.CompareTo(car.Price);

            return 0;
        }

        //string display = $"\t{DateAdded.ToString()}\n" +
        //    $"{Make} -  {Model}\n" +
        //    $"{Color}\n" +
        //    $"{Year}\n" +
        //    $"{Price.ToString("c")}";

        //return display;
}
}
