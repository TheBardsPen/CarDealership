using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class Toyota : Car
    {
        public int Mileage { get; set; }

        public Toyota(string make, string model, string color, int year, int price, int mileage, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            Mileage = mileage;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText() + $"\nMiles: {Mileage}\n";
        }
    }
}
