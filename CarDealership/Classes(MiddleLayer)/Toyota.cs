using CarDealership.Interfaces;
using System;

namespace CarDealership
{
    public class Toyota : Car, ICar
    {
        public int Mileage { get; set; }

        public Toyota(string make, string model, string color, int year, int price, int mileage, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            Mileage = mileage;
        }

        public override string GetDisplayText(string sep)
        {
            return base.GetDisplayText() + $"\nMiles: {Mileage}\n";
        }
    }
}
