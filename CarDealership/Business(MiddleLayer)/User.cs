using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Business_MiddleLayer_
{
    public static class User
    {
        // Variables
        static string UserName { get; set; }
        static List<int> BookmarkIDs { get; set; }
        static bool IsLoggedIn { get; set; } = false;

        public static void Authenticate(string username, string password)
        {
            if (UsersDB.AuthenticateUser(username, password))
            {
                UserName = username;
                BookmarkIDs = UsersDB.bookmarkIDs[username];
                IsLoggedIn = true;
            }
        }

        public static bool Register(string username, string password)
        {
            return UsersDB.RegisterUser(username, password);
        }

        public static void Logout()
        {
            UserName = string.Empty;
            BookmarkIDs.Clear();
            IsLoggedIn = false;
        }

        public static void Save()
        {

        }

        public static void Load()
        {

        }
    }
}
