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
            return base.GetDisplayText() + $"\nEngine: {Engine}\n";
        }
    }
}
