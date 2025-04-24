using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    class Dodge : Car
    {
        public string Engine { get; set; }

        public Dodge(string make, string model, string color, int age, decimal price, string engine)
            : base(make, model, color, age, price)
        {
            this.Engine = engine;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText() + $"\nEngine: {Engine}";
        }
    }
}
