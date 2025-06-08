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
using CarDealership.Business_MiddleLayer_;
using CarDealership.Properties;

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

            if (User.Authenticate(username, password))
            {
                MessageBox.Show($"Welcome, {User.Username}!"); // Show welcome message
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
            
        }

        public void ClearPassword()
        {
            txbPassword.Clear();
            txbUsername.Focus();
        }

        public void ClearForm()
        {
            txbPassword.Clear();
            txbUsername.Clear();
            txbUsername.Focus();
        }

        private void picLock_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible; // Toggle the visibility of the password

            txbPassword.UseSystemPasswordChar = !passwordVisible; // Set the UseSystemPasswordChar property based on the visibility state

            picLock.BackgroundImage = passwordVisible ?
                Resources.Free_Flat_Lock_Open_Icon : Resources.Free_Flat_Lock_Closed_Icon; // Update the button image based on the visibility state
        }
    }
}