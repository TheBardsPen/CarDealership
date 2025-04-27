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
    public partial class frmCarDealership : Form
    {
        // Variables
        public CarList cars = new CarList();

        public frmCarDealership()
        {
            InitializeComponent();
        }

        public void Test(Car car)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCar addCar = new frmAddCar();// Create an instance of the frmAddCar form
            addCar.ShowDialog(); 
        }

        private void cboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();

            if (cboFilterType.Text == "Make")
            {
                cboFilter.Items.Add("Toyota");
                cboFilter.Items.Add("Nissan");
                cboFilter.Items.Add("Dodge");
                cboFilter.Items.Add("Ford");
            }
        }
    }
}
