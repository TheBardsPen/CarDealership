using System;
using System.Collections.Generic;

namespace CarDealership
{
    internal class Dodge : Car
    {
        public string Engine { get; set; }

        public Dodge(string make, string model, string color, int year, int price, string engine, DateTime dateAdded,
            string postedBy, bool isSold, int carID, List<string[]> comments)
            : base(make, model, color, year, price, dateAdded, postedBy, isSold, carID, comments)
        {
            Engine = engine;
        }

        // This method is used to convert the object to a string format for storage
        public override string ToDataString(string sep)
        {
            string commentArray = "";

            foreach (string[] str in Comments)
            {
                commentArray += $"{str[0]}_{str[1]}_{str[2]}{sep}";
            }

            return $"{Make}{sep}{Model}{sep}{Color}{sep}{Year.ToString()}{sep}{Price.ToString()}{sep}{Engine}{sep}" +
                $"{DateAdded}{sep}{PostedBy}{sep}{IsSold}{sep}{CarID}{sep}{commentArray}";
        }

        public override object Clone()
        {
            return new Dodge(Make, Model, Color, Year, Price, Engine, DateAdded, PostedBy, IsSold, CarID, Comments);
        }

        public override string ModelSpecificString()
        {
            string value = Engine;

            return value;
        }
    }
}