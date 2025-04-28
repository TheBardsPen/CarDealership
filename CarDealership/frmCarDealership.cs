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
            cboFilter.Items.Clear();

            // Set enable of filter drowpdown once a filter type is selected
            if (cboFilterType.SelectedIndex != -1)
                cboFilter.Enabled = true;
            else
                cboFilter.Enabled = false;

            // If make is selected, populate the filter dropdown
            if (cboFilterType.Text == "Make")
            {
                cboFilter.Items.Add("Toyota");
                cboFilter.Items.Add("Nissan");
                cboFilter.Items.Add("Dodge");
                cboFilter.Items.Add("Ford");
            }

            // Switch to handle any other possible filter type choice
            switch (cboFilterType.Text)
            {
                case "Color":
                    foreach (Car c in cars)
                    {
                        if (!filters.Contains(c.Color))
                            filters.Add(c.Color);
                    }
                    break;
                case "Price":
                    filters.Add("$0 - $4,999");
                    filters.Add("$5,000 - $9,999");
                    filters.Add("$10,000 +");
                    break;
                case "Age":
                    filters.Add("0 - 5");
                    filters.Add("6 - 10");
                    filters.Add("10 +");
                    break;
                case "Engine":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Dodge))
                        {
                            Dodge d = (Dodge)c;
                            filters.Add(d.Engine);
                        }
                    }
                    break;
                case "Mileage":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Toyota))
                        {
                            Toyota t = (Toyota)c;
                            filters.Add(t.Mileage.ToString());
                        }
                    }
                    break;
                case "Transmission":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Nissan))
                        {
                            Nissan n = (Nissan)c;
                            filters.Add(n.Transmission);
                        }
                    }
                    break;
                case "Trim":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Ford))
                        {
                            Ford f = (Ford)c;
                            filters.Add(f.Trim);
                        }
                    }
                    break;
            }

            // Add each string to the filter dropdown
            cboFilter.Items.AddRange(filters.ToArray());
        }

        private void frmCarDealership_Load(object sender, EventArgs e)
        {

        }
    }
}
