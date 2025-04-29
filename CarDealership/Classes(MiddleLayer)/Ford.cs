using System;

namespace CarDealership
{
    public class Ford : Car
    {
        public string Trim { get; set; }

        public Ford(string make, string model, string color, int year, int price, string trim, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            Trim = trim;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText() + $"\nTrim: {Trim}\n";
        }
    }
}
