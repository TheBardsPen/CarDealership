using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces
{
    public interface IStorable
    {
        /// <summary>
        /// Use this method to return a string of all vehicle properties for simple data storage.
        /// </summary>
        /// <param name="sep">Use a single character. Will need to use the same character for .Split() on data loading.</param>
        /// <returns></returns>
        string ToDataString(string sep);
    }
}
