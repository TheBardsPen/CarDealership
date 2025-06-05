using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces
{
    public interface ICar : IStorable, IDisplayable, ICloneable, IComparable<ICar>
    {
        // Set public fields as read/write
        string Make { get; set; }
        string Model { get; set; }
        string Color { get; set; }
        int Year { get; set; }
        int Price { get; set; }
        DateTime DateAdded { get; set; }
        string PostedBy { get; set; }
        bool IsSold { get; set; }
        int CarID { get; set; }
        List<string[]> Comments { get; set;}
    }
}
