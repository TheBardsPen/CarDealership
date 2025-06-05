using CarDealership.Business_MiddleLayer_;
using CarDealership.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CarDealership
{
    public abstract class Car : ICar
    {
        // Set public fields as read/write
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string PostedBy { get; set; } // Added PostedBy to track who posted the car
        public bool IsSold { get; set; }
        public int CarID { get; set; }
        public List<string[]> Comments { get; set; }

        // Build constructor
        public Car(string make, string model, string color, int year, int price, DateTime dateAdded, string postedBy, bool isSold, int carID, List<string[]> comments)
        {
            Make = make;
            Model = model;
            Color = color;
            Year = year;
            Price = price;
            DateAdded = dateAdded;
            PostedBy = postedBy;
            IsSold = isSold;
            CarID = carID;
            Comments = comments;
        }

        public abstract object Clone();

        public int CompareTo(ICar other) =>
            Price.CompareTo(other.Price);

        public abstract string GetDisplayText(string sep = "\n");

        public abstract string ToDataString(string sep);

        public abstract string ModelSpecificString();

        public void AddComment(string comment)
        {
            Comments.Insert(0, new string[] {"Anonymous", $"{DateTime.Now}", comment});
        }

        public void AddComment(string comment, string user)
        {
            Comments.Insert(0, new string[] { user, $"{DateTime.Now}", comment });
        }

        public void AddComment(string comment, string user, DateTime timePosted)
        {
            Comments.Insert(0, new string[] { user, timePosted.ToString(), comment });
        }

        public string GetCommentLine(string[] comment)
        {
            string c = $"<{comment[0]}> - {comment[1]}\n" +
                        $"{comment[2]}";

            return c;
        }
    }
}