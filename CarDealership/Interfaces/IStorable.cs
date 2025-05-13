using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces
{
    public interface IStorable
    {
        string ToDataString(string sep); // no labels like "Make: "
    }
}
