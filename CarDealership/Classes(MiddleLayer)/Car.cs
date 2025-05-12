using CarDealership.Interfaces;
using System;
using System.Security.Cryptography.X509Certificates;

namespace CarDealership
{
    public abstract class Car : ICar, IDisplayable
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

        public abstract object Clone();

        public int CompareTo(ICar other) =>
            Price.CompareTo(other.Price);

        public abstract string GetDisplayText(string sep = "\n");

        //public virtual string GetDisplayText(string sep)
        //{
        //    string display = $"\t{DateAdded.ToString()}\n" +
        //        $"{Make} -  {Model}\n" +
        //        $"{Color}\n" +
        //        $"{Year}\n" +
        //        $"{Price.ToString("c")}";

        //    return display;
        //}
    }
}
