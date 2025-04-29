using System;
using System.Collections;
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
    public partial class frmDeleteCar : Form
    {
        public CarList cars = new CarList();

        public void carSelect(CarList cars)
        {
            foreach (Car c in cars)
            {
                lB1.Items.Add(c.DateAdded.ToShortDateString() + " " + c.Year + " " + c.Make + " " + c.Model);
            }
        }

        public frmDeleteCar()
        {
            InitializeComponent();
        }

        private void btnCancelDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Show a confirmation dialog
            DialogResult button = MessageBox.Show(
                                    $"Are you sure you want to delete this {cars[lB1.SelectedIndex].Make}? This action cannot be undone.",
                                    "Confirm Delete",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (button == DialogResult.Yes)
            {
                Tag = lB1.SelectedIndex;
                DialogResult = DialogResult.OK;
            }
            }

        private void frmDeleteCar_Load(object sender, EventArgs e)
        {
            carSelect(cars);
        }
    }
}
