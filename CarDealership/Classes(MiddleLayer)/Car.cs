using CarDealership.Interfaces;
using System;
using System.Security.Cryptography.X509Certificates;

namespace CarDealership
{
    public abstract class Car : ICar
    {
        // Set public fields as read/write
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string PostedBy { get; set; } // Added PostedBy to track who posted the car
        public bool IsSold { get; set; }
        public int CarID { get; set; }

        // Build constructor
        public Car(string make, string model, string color, int year, int price, DateTime dateAdded, string postedBy, bool isSold, int carID)
        {
            Make = make;
            Model = model;
            Color = color;
            Year = year;
            Price = price;
            DateAdded = dateAdded;
            PostedBy = postedBy;
            IsSold = isSold;
            CarID = carID;
        }

        public abstract object Clone();

        public int CompareTo(ICar other) =>
            Price.CompareTo(other.Price);

        public abstract string GetDisplayText(string sep = "\n");

        public abstract string ToDataString(string sep);
    }
}