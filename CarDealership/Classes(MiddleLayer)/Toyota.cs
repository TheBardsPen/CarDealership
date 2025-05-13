using CarDealership.Interfaces;
using System;

namespace CarDealership
{
    public class Toyota : Car, ICar, IStorable
    {
        public int Mileage { get; set; }

        public Toyota(string make, string model, string color, int year, int price, int mileage, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            Mileage = mileage;
        }

        public override string GetDisplayText(string sep)
        {
            //string dislpay =
            //    '\t' + DateAdded.ToString() +
            //    Make + sep +
            //    Model + sep +
            //    Color + sep +
            //    Year.ToString() + sep +
            //    Price.ToString() + sep +
            //    "Mileage: " + Mileage.ToString();

            string display = 
                $"Date Added: {DateAdded}{sep}" +
                $"Make: {Make}{sep}" +
                $"Model: {Model}{sep}" +
                $"Color: {Color}{sep}" +
                $"Year: {Year}{sep}" +
                $"Price: {Price.ToString("c")}{sep}" +
                $"Mileage: {Mileage.ToString()}";


            return display + sep+ "\n";
        }

        // This method is used to convert the object to a string format for storage
        public override string ToDataString(string sep)
        {
            return $"{Make}{sep}{Model}{sep}{Color}{sep}{Year.ToString()}{sep}{Price.ToString()}{sep}{Mileage.ToString()}{sep}{DateAdded}";
        }

        public override object Clone()
        {
            return new Toyota(Make, Model, Color, Year, Price, Mileage, DateAdded);
        }
    }
}
