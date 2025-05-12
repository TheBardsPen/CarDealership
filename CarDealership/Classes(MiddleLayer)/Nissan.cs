using CarDealership.Interfaces;
using System;

namespace CarDealership
{
    public class Nissan : Car, ICar
    {
        public string Transmission { get; set; }

        public Nissan(string make, string model, string color, int year, int price, string transmisson, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            Transmission = transmisson;
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
            //    "Transmission: " + Transmission;

            //return dislpay;

            string display =
                $"Date Added: {DateAdded}{sep}" +
                $"Make: {Make}{sep}" +
                $"Model: {Model}{sep}" +
                $"Color: {Color}{sep}" +
                $"Year: {Year}{sep}" +
                $"Price: {Price.ToString("c")}{sep}" +
                $"Transmission: {Transmission}";

            return display + sep + "\n";
        }

        public override object Clone()
        {
            return new Nissan(Make, Model, Color, Year, Price, Transmission, DateAdded);
        }
    }
}
