using CarDealership.Interfaces;
using System;

namespace CarDealership
{
    public class Nissan : Car
    {
        public string Transmission { get; set; }

        public Nissan(string make, string model, string color, int year, int price, string transmisson, DateTime dateAdded, string postedBy)
            : base(make, model, color, year, price, dateAdded, postedBy)
        {
            Transmission = transmisson;
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
                $"Transmission: {Transmission}" +
                "Seller: {PostedBy}";

            return display + sep + "\n";
        }

        // This method is used to convert the object to a string format for storage
        public override string ToDataString(string sep)
        {
            return $"{Make}{sep}{Model}{sep}{Color}{sep}{Year.ToString()}{sep}{Price.ToString()}{sep}{Transmission}{sep}{DateAdded}{sep}{PostedBy}";
        }

        public override object Clone()
        {
            return new Nissan(Make, Model, Color, Year, Price, Transmission, DateAdded, PostedBy);
        }
    }
}