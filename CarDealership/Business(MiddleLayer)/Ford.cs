﻿using System;
using System.Collections.Generic;

namespace CarDealership
{
    public class Ford : Car
    {
        public string Trim { get; set; }

        public Ford(string make, string model, string color, int year, int price, string trim, DateTime dateAdded,
            string postedBy, bool isSold, int carID, List<string[]> comments)
            : base(make, model, color, year, price, dateAdded, postedBy, isSold, carID, comments)
        {
            Trim = trim;
        }

        // This method is used to convert the object to a string format for storage
        public override string ToDataString(string sep)
        {
            string commentArray = "";

            foreach (string[] str in Comments)
            {
                commentArray += $"{str[0]}_{str[1]}_{str[2]}{sep}";
            }

            return $"{Make}{sep}{Model}{sep}{Color}{sep}{Year.ToString()}{sep}{Price.ToString()}{sep}{Trim}{sep}" +
                $"{DateAdded}{sep}{PostedBy}{sep}{IsSold}{sep}{CarID}{sep}{commentArray}";
        }

        public override object Clone()
        {
            return new Ford(Make, Model, Color, Year, Price, Trim, DateAdded, PostedBy, IsSold, CarID, Comments);
        }

        public override string ModelSpecificString()
        {
            string value = Trim;

            return value;
        }
    }
}