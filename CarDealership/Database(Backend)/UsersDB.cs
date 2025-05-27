using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
        public static Dictionary<string, string> users = new Dictionary<string, string>(); // Initialize the dictionary to store users
        public static Dictionary<string, List<int>> bookmarkIDs = new Dictionary<string, List<int>>();

        /// Set the current user to an empty string
        public static string CurrentUser { get; set; } = string.Empty;

        public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUser); // Check if the user is logged in

        public static List<int> UserBookmarkIDs = new List<int>(); // List of CarIDs the user has bookmarked

        // Set VersionID and last compatible version to eliminate restructure issues on loading
        // This could be eliminated with a server based database instead of local
        private const int VersionID = 6;
        private const int LastCompatibleVersionID = 6;

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
                bookmarkIDs.Clear();

                // Check if file exists
                if (File.Exists(filePath))
                {
                    // Get save file and initialize list
                    using (StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read))) // open file for reading
                    {
                        // Check the version for version control
                        string versionRow = reader.ReadLine();
                        string[] versionColumns = versionRow.Split(':');

                        if (versionColumns[0] != "Version" ||
                            Convert.ToInt32(versionColumns[1]) < LastCompatibleVersionID)
                        {
                            bookmarkIDs = new Dictionary<string, List<int>>();
                            users = new Dictionary<string, string>();
                            return OutDatedDictionary();
                        }

                        string tempUser = ""; // Set a variable username that can be carried over to the next loop

                        while (reader.Peek() != -1)
                        {
                            // Break down file into rows and columns
                            string line = reader.ReadLine();
                            string[] parts = line.Split('|');

                            

                            // Check if the line has exactly two parts (username and password)
                            if (parts.Length == 2 &&
                                parts[0] != "-fillbookmark-" &&
                                parts[0] != "-nullbookmark-")
                            {
                                tempUser = parts[0];
                                string username = parts[0];
                                string password = parts[1];
                                // Add the user to the dictionary
                                users.Add(username, password);
                            }
                            else if (parts[0] == "-fillbookmark-")
                            {
                                foreach (string str in parts)
                                    bookmarkIDs[tempUser].Add(Convert.ToInt32(str));
                            }
                            else
                            {
                                bookmarkIDs[tempUser] = new List<int>();
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
                    // Write version for compatible loading
                    writer.WriteLine($"Version:{VersionID}");

                    foreach (var user in users)
                    {
                        writer.WriteLine($"{user.Key}|{user.Value}"); // Write each user to the file

                        if (bookmarkIDs[user.Key].Count > 0)
                        {
                            writer.Write("-fillbookmark-|");
                            foreach (int i in bookmarkIDs[user.Key])
                                writer.Write($"{i}|");
                        }
                        else
                            writer.Write("-nullbookmark-");
                        //writer.WriteLine("Bookmark");
                        //if (user.Key == CurrentUser)
                        //    foreach (int i in UserBookmarkIDs) // Write each carID of users bookmarks
                        //        writer.Write(UserBookmarkIDs[i].ToString() + "|");
                        writer.WriteLine();
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
            string lowerUsername = username.ToLower(); // Create a lower case version of user input            

            LoadUsers(); // Load users from the file
            SaveUsers(users);

            List<string> normalUsers = new List<string>(); // Create a list of original usernames and lower usernames to use indexes
            List<string> lowerUsers = new List<string>();

            if (users.Count > 0)
            {
                foreach (string str in users.Keys)
                {
                    normalUsers.Add(str);
                    lowerUsers.Add(str.ToLower());
                }

                if (lowerUsers.Contains(lowerUsername) &&
                    users.TryGetValue(normalUsers[lowerUsers.IndexOf(lowerUsername)], out string storedPassword))
                {
                    if (storedPassword.Equals(password))
                    {
                        CurrentUser = normalUsers[lowerUsers.IndexOf(lowerUsername)];

                        // Return listingIDs and bookmarkIDs for user
                        GetListingIDs();

                        return true;
                    }
                }
            }
            
            return false; // Return false if authentication fails
        }

        /// <summary>
        /// Registers a new user if the username is not already taken.
        /// </summary>
        public static bool RegisterUser(string username, string password)
        {
            string lowerUsername = username.ToLower(); // Create a lower case version of user input
            List<string> lowerUsers = new List<string>(); // Create list of lowercase usernames to avoid case problems

            LoadUsers(); // Load users from the file

            if (users.Count > 0)
            {
                foreach (string str in users.Keys)
                {
                    lowerUsers.Add(str.ToLower()); // Add lowercase usernames to a list to compare input usernmame
                }
            }

            if (lowerUsers.Contains(lowerUsername))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                // Add the new user to the dictionary
                users.Add(username, password);
                bookmarkIDs.Add(username, new List<int>());
                SaveUsers(users); // Save the updated users to the file
                MessageBox.Show("User registered successfully.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }

        private static List<int> GetListingIDs()
        {
            List<int> ids = bookmarkIDs[CurrentUser];

            return ids;
        }

        public static void Logout()
        {
            CurrentUser = string.Empty; // Clear the current user
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> OutDatedDictionary()
        {
            MessageBox.Show("Your local data is not compatible with this version of the application. " +
                "We appologize for the inconvenience.\n\n" +
                "Creating new file...",
                "User List Out of Date",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return new Dictionary<string,string>();
        }
    }
}