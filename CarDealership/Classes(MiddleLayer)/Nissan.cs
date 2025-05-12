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
            string dislpay =
                '\t' + DateAdded.ToString() +
                Make + sep +
                Model + sep +
                Color + sep +
                Year.ToString() + sep +
                Price.ToString() + sep +
                "Transmission: " + Transmission;

            return dislpay;
        }

        public override object Clone()
        {
            return new Nissan(Make, Model, Color, Year, Price, Transmission, DateAdded);
        }
    }
}
