using System;
using System.Collections.Generic;
using CarDealership.Interfaces;

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
        public string PostedBy { get; set; }
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

        public abstract string GetDisplayText(string sep = "\n");

        public abstract string ToDataString(string sep);

        /// <summary>
        /// A <c>string</c> representation of the model specific properties.
        /// </summary>
        public abstract string ModelSpecificString();

        /// <summary>
        /// Creates a single <c>string[]</c> for comment storage.
        /// </summary>
        /// <param name="comment">The text of the comment</param>
        public void AddComment(string comment)
        {
            Comments.Insert(0, new string[] { "Anonymous", $"{DateTime.Now}", comment });
        }

        /// <summary>
        /// Creates a single <c>string[]</c> for comment storage.
        /// </summary>
        /// <param name="comment">The text of the comment</param>
        /// <param name="user">The user that posted the comment</param>
        public void AddComment(string comment, string user)
        {
            Comments.Insert(0, new string[] { user, $"{DateTime.Now}", comment });
        }

        /// <summary>
        /// Creates a single <c>string[]</c> for comment storage.
        /// </summary>
        /// <param name="comment">The text of the comment</param>
        /// <param name="user">The user that posted the comment</param>
        /// <param name="timePosted">The <c>DateTime</c> the comment was posted</param>
        public void AddComment(string comment, string user, DateTime timePosted)
        {
            Comments.Insert(0, new string[] { user, timePosted.ToString(), comment });
        }

        /// <summary>
        /// Writes a saved <c>string[]</c> to a single <c>string</c> for comment display.
        /// </summary>
        /// <param name="comment">The stored <c>string[]</c> to display</param>
        public string GetCommentLine(string[] comment)
        {
            string c = $"<{comment[0]}> - {comment[1]}\n" +
                        $"{comment[2]}";

            return c;
        }
    }
}