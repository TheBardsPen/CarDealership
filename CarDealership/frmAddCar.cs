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
    public partial class frmAddCar: Form
    {
        public frmAddCar()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddCar_Load(object sender, EventArgs e)
        {
            // Populate the make combo box with car makes
            cboMake.Items.Add("Dodge");
            cboMake.Items.Add("Ford");
            cboMake.Items.Add("Honda");
            cboMake.Items.Add("Toyota");

        }
    }
}
