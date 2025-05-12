using System;
using System.Windows.Forms;
using CarDealership.Interfaces;

namespace CarDealership
{
    public partial class frmDeleteCar : Form
    {
        public CarList<ICar> cars = new CarList<ICar>();

        public void CarSelect(CarList<ICar> cars)
        {
            foreach (ICar c in cars)
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
            if (lB1.SelectedItem != null)
            {
                // Show a confirmation dialog
                ICar selectedCar = cars[lB1.SelectedIndex]; 
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
        }

        private void frmDeleteCar_Load(object sender, EventArgs e)
        {
            CarSelect(cars);
        }
    }
}
