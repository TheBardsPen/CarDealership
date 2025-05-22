using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CarDealership
{
    public static class UsersDB
    {
        /// <summary>
        /// This class is used to load and save the Cars.txt file.
        /// </summary>

        // Set directory and filename
        private const string dir = @"C:\C#\Files\CarDealerShipUsers";

        private const string file = "Users.txt";

        // Initialize the dictionary to store users
        private static Dictionary<string, string> users = new Dictionary<string, string>(); // Initialize the dictionary to store users

        /// Set the current user to an empty string
        public static string CurrentUser { get; set; } = string.Empty;

        public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUser); // Check if the user is logged in

        /// <summary>
        /// Loads users from the Users.txt file.
        /// </summary>

        public static Dictionary<string, string> LoadUsers()
        {
            try
            {
                // Check if directory exists, if not create it
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string filePath = Path.Combine(dir, file); // combine directory and file

                users.Clear(); // Clear the dictionary before loading users

                // Check if file exists
                if (File.Exists(filePath))
                {
                    // Get save file and initialize list
                    using (StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))) // open file for reading
                    {
                        while (reader.Peek() != -1)
                        {
                            // Break down file into rows and columns
                            string line = reader.ReadLine();
                            string[] parts = line.Split('|');

                            // Check if the line has exactly two parts (username and password)
                            if (parts.Length == 2 && !users.ContainsKey(parts[0]))
                            {
                                string username = parts[0];
                                string password = parts[1];
                                // Add the user to the dictionary
                                users.Add(username, password);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                //Handle the specific execptions when file cant be found
                MessageBox.Show("File not Found. Creating a new file.", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            return users; // Return the dictionary of users
        }

        /// <summary>
        /// Saves users to the Users.txt file.
        /// </summary>
        public static void SaveUsers(Dictionary<string, string> users)
        {
            try
            {
                // Check if directory exists, if not create it
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string filePath = Path.Combine(dir, file); // combine directory and file
                using (StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write))) // open file for writing
                {
                    foreach (var user in users)
                    {
                        writer.WriteLine($"{user.Key}|{user.Value}"); // Write each user to the file
                    }
                }
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
        /// Authenticates the user by checking if the username and password match.
        /// </summary>>
        public static bool AuthenticateUser(string username, string password)
        {
            LoadUsers(); // Load users from the file

            if (users.TryGetValue(username, out string storedPassword))
            {
                if (storedPassword.Equals(password))
                {
                    CurrentUser = username;
                    return true;
                }
            }
            return false; // Return false if authentication fails
        }

        /// <summary>
        /// Registers a new user if the username is not already taken.
        /// </summary>
        public static void RegisterUser(string username, string password)
        {
            LoadUsers(); // Load users from the file

            if (users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Add the new user to the dictionary
                users.Add(username, password);
                SaveUsers(users); // Save the updated users to the file
                MessageBox.Show("User registered successfully.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}