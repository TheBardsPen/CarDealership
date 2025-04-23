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

            public Toyota(string make, string model, string color, int age, decimal price, int mileage)
                : base(make, model, color, age, price)
            {
                Mileage = mileage;
            }

            public override string GetDisplayText()
            {
                return base.GetDisplayText() + $"\n{Mileage}";
            }
        }
}
