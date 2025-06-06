namespace CarDealership.Interfaces
{
    public interface IStorable
    {
        /// <summary>
        /// Use this method to return a string of all vehicle properties for simple data storage.
        /// </summary>
        /// <param name="sep">Use a single character. Will need to use the same character for .Split() on data loading.</param>
        string ToDataString(string sep);
    }
}
