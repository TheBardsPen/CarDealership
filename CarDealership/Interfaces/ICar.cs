using System;
using System.Collections.Generic;

namespace CarDealership.Interfaces
{
    public interface ICar : IStorable, IDisplayable, ICloneable
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
        List<string[]> Comments { get; set; }
    }
}
