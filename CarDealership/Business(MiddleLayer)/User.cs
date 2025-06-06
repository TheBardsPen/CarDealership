using System.Collections.Generic;

namespace CarDealership.Business_MiddleLayer_
{
    public static class User
    {
        // Variables
        public static string Username { get; set; }
        public static List<int> BookmarkIDs { get; set; }
        public static bool IsLoggedIn { get; set; } = false;

        public static bool Authenticate(string username, string password)
        {
            if (UsersDB.AuthenticateUser(username, password))
            {
                Username = UsersDB.CurrentUser;
                BookmarkIDs = UsersDB.bookmarkIDs[Username];
                IsLoggedIn = true;
                return true;
            }

            return false;
        }

        public static bool Register(string username, string password)
        {
            return UsersDB.RegisterUser(username, password);
        }

        public static void Logout()
        {
            Username = string.Empty;
            BookmarkIDs.Clear();
            IsLoggedIn = false;
            UsersDB.Logout();
        }

        public static void Remove(string username)
        {
            UsersDB.users.Remove(username);
            UsersDB.SaveUsersList(UsersDB.users);
        }

        public static void Save()
        {
            UsersDB.SaveSingleUser(Username, BookmarkIDs);
        }

        public static void Load()
        {
            UsersDB.LoadUsersList();
        }
    }
}
