using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the registration form
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim(); // Get the username from the text box
            string password = txbPassword.Text; // Get the password from the text box
            string confirmPassword = txbConfirmPassword.Text; // Get the confirmed password from the text box

            // Check if the username is empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password is required."); // Show error message
                return; // Exit the method
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match."); // Show error message
                return; // Exit the method
            }

            UsersDB.RegisterUser(username, password); // Register the user

            // Check if the registration was successfu
            if (UsersDB.CurrentUser != string.Empty && UsersDB.CurrentUser != "Guest")
            {
                this.Close(); // Close the registration form
            }
        }
    }
}