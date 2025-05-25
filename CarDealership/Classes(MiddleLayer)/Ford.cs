using CarDealership.Interfaces;
using System;
using System.Runtime.Remoting.Lifetime;

namespace CarDealership
{
    public class Ford : Car
    {
        public string Trim { get; set; }

        public Ford(string make, string model, string color, int year, int price, string trim, DateTime dateAdded,
            string postedBy, bool isSold, int carID)
            : base(make, model, color, year, price, dateAdded, postedBy, isSold, carID)
        {
            Trim = trim;
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
                $"Trim: {Trim}{sep}" +
                $"Seller: {PostedBy}";

            return display + sep + "\n";
        }

        // This method is used to convert the object to a string format for storage
        public override string ToDataString(string sep)
        {
            return $"{Make}{sep}{Model}{sep}{Color}{sep}{Year.ToString()}{sep}{Price.ToString()}{sep}{Trim}" +
                $"{sep}{DateAdded}{sep}{PostedBy}{sep}{IsSold}{sep}{CarID}";
        }

        public override object Clone()
        {
            return new Ford(Make, Model, Color, Year, Price, Trim, DateAdded, PostedBy, IsSold, CarID);
        }
    }
}