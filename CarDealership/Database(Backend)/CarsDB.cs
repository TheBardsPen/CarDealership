using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CarDealership.Interfaces;

namespace CarDealership
{
    public class CarsDB<T> where T : ICar, IStorable
    {
        // Set directory and filename
        private const string dir = @"C:\C#\Files\AngelMay_ShaneHubbard_CalvinBorgaard\";
        private const string file = "Cars.txt";

        // Set VersionID and last compatible version to eliminate restructure issues on loading
        // This could be eliminated with a server based database instead of local
        private const int VersionID = 7;
        private const int LastCompatibleVersionID = 7;

        // Start counter at 0 for CarID
        public static int NextID { get; set; } = 0;

        /// <summary>
        /// Creates a <c>CarList</c> that contains everything from the 'Cars.txt' file.
        /// </summary>
        /// <returns></returns>
        public static List<T> LoadCars()
        {
            try
            {
                // Check if directory exists, if not create it
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string filePath = Path.Combine(dir, file);

                // Check if file exists
                if (File.Exists(filePath))
                {
                    // Get save file and initialize list
                    using (StreamReader text = new StreamReader(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read)))
                    {
                        List<T> cars = new List<T>();

                        // Check the version for version control
                        string versionRow = text.ReadLine();
                        string[] versionColumns = versionRow.Split(':');

                        if (versionColumns[0] != "Version" ||
                            Convert.ToInt32(versionColumns[1]) < LastCompatibleVersionID)
                        {
                            return OutDatedList();
                        }

                        while (text.Peek() != -1)
                        {
                            // Break down file into rows and columns
                            string row = text.ReadLine();
                            string[] columns = row.Split('|');

                            if (columns.Length < 10)
                                continue;

                            // Switch to pull what Make (subclass) to create
                            ICar c;
                            switch (columns[0])
                            {
                                case "Dodge":
                                    c = new Dodge(
                                        columns[0],
                                        columns[1],
                                        columns[2],
                                        Convert.ToInt32(columns[3]),
                                        Convert.ToInt32(columns[4]),
                                        columns[5],
                                        DateTime.Parse(columns[6]),
                                        columns[7],
                                        Convert.ToBoolean(columns[8]),
                                        Convert.ToInt32(columns[9]),
                                        new List<string[]>());
                                    break;

                                case "Ford":
                                    c = new Ford(
                                        columns[0],
                                        columns[1],
                                        columns[2],
                                        Convert.ToInt32(columns[3]),
                                        Convert.ToInt32(columns[4]),
                                        columns[5],
                                        DateTime.Parse(columns[6]),
                                        columns[7],
                                        Convert.ToBoolean(columns[8]),
                                        Convert.ToInt32(columns[9]),
                                        new List<string[]>());
                                    break;

                                case "Toyota":
                                    c = new Toyota(
                                        columns[0],
                                        columns[1],
                                        columns[2],
                                        Convert.ToInt32(columns[3]),
                                        Convert.ToInt32(columns[4]),
                                        Convert.ToInt32(columns[5]),
                                        DateTime.Parse(columns[6]),
                                        columns[7],
                                        Convert.ToBoolean(columns[8]),
                                        Convert.ToInt32(columns[9]),
                                        new List<string[]>());
                                    break;

                                case "Nissan":
                                    c = new Nissan(
                                        columns[0],
                                        columns[1],
                                        columns[2],
                                        Convert.ToInt32(columns[3]),
                                        Convert.ToInt32(columns[4]),
                                        columns[5],
                                        DateTime.Parse(columns[6]),
                                        columns[7],
                                        Convert.ToBoolean(columns[8]),
                                        Convert.ToInt32(columns[9]),
                                        new List<string[]>());
                                    break;

                                default:
                                    // Not a valid "Car". Move to next iteration
                                    continue;
                            }

                            // Set comment list
                            List<string[]> comments = new List<string[]>();

                            for (int i = 10; i < columns.Length - 1; i++)
                            {
                                string[] comment = columns[i].Split('_');
                                comments.Add(comment);
                            }
                            c.Comments = comments;

                            cars.Add((T)c);
                            NextID = cars[0].CarID + 1; // Return latest (highest) car to set NextID
                        }

                        return cars;
                    }
                }

                // Return an empty List if File does not exist.
                return new List<T>();
            }
            catch (FileNotFoundException)
            {
                //Handle the specific execptions when file cant be found
                MessageBox.Show("File not Found. Creating a new file.", "File not Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new List<T>();
            }
            catch (DirectoryNotFoundException ex)
            {
                // handles cases wjere the specific directory could not be found
                MessageBox.Show("Directory not found: " + ex.Message, "Directory Not Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (IOException ex)
            {
                // handles general IOexceptions that occur when trying to access the file
                MessageBox.Show("An error occured while accessing the file: " + ex.Message, "IO Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                //catches any unexpected exceptiuons that dont match the previous ones.
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Writes the <c>CarList</c> to a .txt file.
        /// </summary>
        /// <param name="cars">The CarList to save</param>
        public static void SaveCars(List<T> cars)
        {
            // Extra safety check to ensure directory exists and create it if not
            try
            {
                // Check if directory exists, if not create it
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string filePath = Path.Combine(dir, file);
                using (StreamWriter text = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write)))
                {
                    // Write version for compatible loading
                    text.WriteLine($"Version:{VersionID}");

                    // Write the data string to the file
                    foreach (T car in cars)
                    {
                        text.WriteLine(car.ToDataString("|"));
                    }
                }
            }
            catch (IOException ex)
            {
                // Handle IO exceptions
                MessageBox.Show("Error saving to file" + ex.Message, "IO Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                MessageBox.Show("Unexpected error" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// This method returns a new list if the application version is incompatible with the version of the save file.
        /// </summary>
        private static List<T> OutDatedList()
        {
            MessageBox.Show("Your local data is not compatible with this version of the application. " +
                "We appologize for the inconvenience.\n\n" +
                "Creating new file...",
                "Version Out of Date",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return new List<T>();
        }
    }
}