using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class Ford : Car
    {
        public string History { get ; set; }

        public Ford(string make, string model, string color, int age, decimal price, string history)
            : base(make, model, color, age, price)
        {
            History = history;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText() + $"\n{History}";
        }
    }
}
