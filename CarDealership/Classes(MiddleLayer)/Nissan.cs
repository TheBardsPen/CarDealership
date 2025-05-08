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
            return base.GetDisplayText() + $"\nTransmission: {Transmission}\n";
        }
    }
}
