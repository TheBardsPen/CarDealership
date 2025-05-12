using CarDealership.Interfaces;
using System;

namespace CarDealership
{
    class Dodge : Car, ICar
    {
        public string Engine { get; set; }

        public Dodge(string make, string model, string color, int year, int price, string engine, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            this.Engine = engine;
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
                "Engine: " + Engine;

            return dislpay;
        }

        public override object Clone()
        {
            return new Dodge(Make, Model, Color, Year, Price, Engine, DateAdded);
        }
    }
}
