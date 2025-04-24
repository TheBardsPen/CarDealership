using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class Nissan : Car
    {
        public string Transmission { get; set; }

        public Nissan(string make, string model, string color, int age, decimal price, string transmisson)
            : base(make, model, color, age, price)
        {
            Transmission = transmisson;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText() + $"\nTransmission: {Transmission}";
        }
    }
}
