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

        public Dodge(string make, string model, string color, int year, int price, string engine, DateTime dateAdded)
            : base(make, model, color, year, price, dateAdded)
        {
            this.Engine = engine;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText() + $"\nEngine: {Engine}";
        }
    }
}
