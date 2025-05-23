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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            UsersDB.CurrentUser = "Guest"; // Set the current user to Guest
            frmCarDealership mainForm = new frmCarDealership(); // Create a new instance of the main form
            mainForm.Show(); // Show the main form
            this.Hide(); // Hide the login form
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister registerUser = new frmRegister(); // Create a new instance of the registration form
        }
    }
}