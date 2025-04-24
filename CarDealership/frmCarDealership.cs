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
        public SortedList<Car, DateTime> carList = new SortedList<Car, DateTime>();

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
    }
}
