using CarDealership.Interfaces;
using System;
using System.Runtime.Remoting.Lifetime;

namespace CarDealership
{
    internal class Dodge : Car
    {
        public string Engine { get; set; }

        public Dodge(string make, string model, string color, int year, int price, string engine, DateTime dateAdded, string postedBy)
            : base(make, model, color, year, price, dateAdded, postedBy)
        {
            this.Engine = engine;
        }

        public override string GetDisplayText(string sep)
        {
            string display =
                $"Date Added: {DateAdded}{sep}" +
                $"Make: {Make}{sep}" +
                $"Model: {Model}{sep}" +
                $"Color: {Color}{sep}" +
                $"Year: {Year}{sep}" +
                $"Price: {Price.ToString("c")}{sep}" +
                $"Engine: {Engine}{sep}" +
                $"Seller: {PostedBy}";

            return display + sep + "\n";
        }

        // This method is used to convert the object to a string format for storage
        public override string ToDataString(string sep)
        {
            return $"{Make}{sep}{Model}{sep}{Color}{sep}{Year.ToString()}{sep}{Price.ToString()}{sep}{Engine}{sep}{DateAdded}{sep}{PostedBy}";
        }

        public override object Clone()
        {
            return new Dodge(Make, Model, Color, Year, Price, Engine, DateAdded, PostedBy);
        }
    }
}