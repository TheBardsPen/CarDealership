using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealership
{
    public partial class frmLogin : Form
    {
        private bool passwordVisible = false; // Variable to track if the password should be shown

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            UsersDB.CurrentUser = "Guest"; // Set the current user to Guest
            frmCarDealership mainForm = new frmCarDealership(); // Create a new instance of the main form
            mainForm.loginForm = this;
            mainForm.Show(); // Show the main form
            this.Hide(); // Hide the login form

            txbPassword.Clear();
            txbUsername.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister registerUser = new frmRegister(); // Create a new instance of the registration form
            registerUser.ShowDialog(); // Show the registration form
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim(); // Get the username from the text box
            string password = txbPassword.Text; // Get the password from the text box

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password is required."); // Show error message
                return; // Exit the method
            }

            if (UsersDB.AuthenticateUser(username, password))
            {
                MessageBox.Show($"Welcome, {UsersDB.CurrentUser}!"); // Show welcome message
                frmCarDealership mainForm = new frmCarDealership();
                mainForm.loginForm = this;
                mainForm.Show(); // Show the main form
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password."); // Show error message
                txbPassword.SelectAll();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible; // Toggle the visibility of the password

            txbPassword.UseSystemPasswordChar = !passwordVisible; // Set the UseSystemPasswordChar property based on the visibility state

            btnShowPassword.Text = passwordVisible ? "Hide Password" : "Show Password"; // Update the button text based on the visibility state
        }

        public void ClearPassword()
        {
            txbPassword.Clear();
            txbUsername.Focus();
        }
    }
}