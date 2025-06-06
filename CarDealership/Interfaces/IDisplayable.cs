namespace CarDealership.Interfaces
{
    public interface IDisplayable
    {
        /// <summary>
        /// Use this method to return a string to display the vehicle information.
        /// </summary>
        /// <param name="sep">White space or other character used to seperate the properties</param>
        string GetDisplayText(string sep = "\n");
    }
}
