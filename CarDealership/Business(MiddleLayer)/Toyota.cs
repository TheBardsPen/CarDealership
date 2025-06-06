using System;
using System.Collections.Generic;

namespace CarDealership
{
    public class Toyota : Car
    {
        public int Mileage { get; set; }

        public Toyota(string make, string model, string color, int year, int price, int mileage, DateTime dateAdded,
            string postedBy, bool isSold, int carID, List<string[]> comments)
            : base(make, model, color, year, price, dateAdded, postedBy, isSold, carID, comments)
        {
            Mileage = mileage;
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
                $"Mileage: {Mileage.ToString("n0")}{sep}" +
                $"Seller: {PostedBy}";

            return display + sep + "\n";
        }

        // This method is used to convert the object to a string format for storage
        public override string ToDataString(string sep)
        {
            string commentArray = "";

            foreach (string[] str in Comments)
            {
                commentArray += $"{str[0]}_{str[1]}_{str[2]}{sep}";
            }

            return $"{Make}{sep}{Model}{sep}{Color}{sep}{Year.ToString()}{sep}{Price.ToString()}{sep}{Mileage.ToString()}{sep}" +
                $"{DateAdded}{sep}{PostedBy}{sep}{IsSold}{sep}{CarID}{sep}{commentArray}";
        }

        public override object Clone()
        {
            return new Toyota(Make, Model, Color, Year, Price, Mileage, DateAdded, PostedBy, IsSold, CarID, Comments);
        }

        public override string ModelSpecificString()
        {
            string value = Mileage.ToString("n0");

            return value;
        }
    }
}