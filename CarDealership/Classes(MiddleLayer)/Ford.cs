using CarDealership.Interfaces;
using System;

namespace CarDealership
{
    public class Ford : Car, ICar
    {
        public string Trim { get; set; }

        public Ford(string make, string model, string color, int year, int price, string trim, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            Trim = trim;
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
            //    "Trim: " + Trim;

            //return dislpay;

            string display =
                $"Date Added: {DateAdded}{sep}" +
                $"Make: {Make}{sep}" +
                $"Model: {Model}{sep}" +
                $"Color: {Color}{sep}" +
                $"Year: {Year}{sep}" +
                $"Price: {Price.ToString("c")}{sep}" +
                $"Trim: {Trim}";

            return display + sep + "\n";
        }

        public override object Clone()
        {
            return new Ford(Make, Model, Color, Year, Price, Trim, DateAdded);
        }
    }
}
