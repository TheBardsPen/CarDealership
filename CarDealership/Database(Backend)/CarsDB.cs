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

        // Start counter at 0 for CarID
        public static int NextID { get; set; } = 0;

        /// <summary>
        /// Creates a CarList that contains everything from the 'Cars.txt' file.
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

                string filePath = Path.Combine(dir, file); // combine directory and file

                // Check if file exists
                if (File.Exists(filePath))
                {
                    // Get save file and initialize list
                    using (StreamReader text = new StreamReader(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))) // open file for reading
                    {
                        List<T> cars = new List<T>();

                        while (text.Peek() != -1)
                        {
                            // Break down file into rows and columns
                            string row = text.ReadLine();
                            string[] columns = row.Split('|');

                            if (columns.Length < 8)
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
                                        Convert.ToInt32(columns[9]));
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
                                        Convert.ToInt32(columns[9]));
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
                                        Convert.ToInt32(columns[9]));
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
                                        Convert.ToInt32(columns[9]));
                                    break;

                                default:
                                    continue;
                            }
                            cars.Add((T)c);
                        }
                        NextID = cars[0].CarID + 1; // Return latest (highest) car to set NextID
                        return cars;
                    }
                }
                return new List<T>(); // Return an empty List if File does not exist.
            }
            catch (FileNotFoundException)
            {
                //Handle the specific execptions when file cant be found
                MessageBox.Show("File not Found. Creating a new file.", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new List<T>();
            }
            catch (DirectoryNotFoundException ex)
            {
                // handles cases wjere the specific directory could not be found
                MessageBox.Show("Directory not found: " + ex.Message, "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (IOException ex)
            {
                // handles general IOexceptions that occur when trying to access the file
                MessageBox.Show("An error occured while accessing the file: " + ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                //catches any unexpected exceptiuons that dont match the previous ones.
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Writes the CarList to a .txt file.
        /// </summary>
        /// <param name="cars">The CarList to save</param>
        public static void SaveCars(List<T> cars)
        {
            // Extra safety check to ensure directory exists and create it if not
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string filePath = Path.Combine(dir, file); // combine directory and file
                using (StreamWriter text = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write)))

                    // Write each property of each car to stream
                    // Should be in same order as constructor for ease of loading

                    foreach (T car in cars)
                    {
                        text.WriteLine(car.ToDataString("|")); // Write the data string to the file
                    }
            }
            catch (IOException ex)
            {
                // Handle IO exceptions
                MessageBox.Show("Error saving to file" + ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                MessageBox.Show("Unexpected error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}