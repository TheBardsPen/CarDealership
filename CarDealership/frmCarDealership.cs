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

        private void frmCarDealership_Load(object sender, EventArgs e)
        {
            // Load carlist from database on form load
            cars.Load();
        }

        #region Event Handlers


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCar addCar = new frmAddCar();// Create an instance of the frmAddCar form
            Car newCar = addCar.ReturnCar();// Run method to return a car object

            // Add new car to list
            if (addCar.DialogResult == DialogResult.OK)
                cars.Add(newCar);

            // Save to database
            cars.Save();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            // Clear the list to repopulate
            lbCarList.Text = "";

            // Display all cars in the carlist
            foreach (Car c in cars)
            {
                lbCarList.Text += c.GetDisplayText() + "\n";
            }

            // Reset filter selections
            cboFilterType.Text = "";
            cboFilter.Text = "";
            cboFilter.Enabled = false;
            btnFilter.Enabled = false;
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
                // Pull unique colors from carlist
                case "Color":
                    foreach (Car c in cars)
                    {
                        if (!filters.Contains(c.Color))
                            filters.Add(c.Color);
                    }
                    break;

                // Set filter price ranges
                case "Price":
                    filters.Add("$0 - $4,999");
                    filters.Add("$5,000 - $9,999");
                    filters.Add("$10,000+");
                    break;

                // Set filter to age ranges
                case "Age":
                    filters.Add("0 - 5");
                    filters.Add("6 - 10");
                    filters.Add("11+");
                    break;

                // Check for dodge, and set filter to unique engines from carlist
                case "Engine":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Dodge))
                        {
                            Dodge d = (Dodge)c;
                            if (!filters.Contains(d.Engine))
                                filters.Add(d.Engine);
                        }
                    }
                    break;

                // Set filter to mileage ranges
                case "Mileage":
                    filters.Add("0 - 49,999");
                    filters.Add("50,000 - 99,999");
                    filters.Add("100,000+");
                    break;

                // Check for Nissan, and set filter to unique transmissions from carlist
                case "Transmission":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Nissan))
                        {
                            Nissan n = (Nissan)c;
                            if (!filters.Contains(n.Transmission))
                                filters.Add(n.Transmission);
                        }
                    }
                    break;

                // Check for ford, and set filter to unique trims from carlist
                case "Trim":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Ford))
                        {
                            Ford f = (Ford)c;
                            if (!filters.Contains(f.Trim))
                                filters.Add(f.Trim);
                        }
                    }
                    break;
            }

            // Add each string to the filter dropdown
            cboFilter.Items.AddRange(filters.ToArray());
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilter.Text != "Filter...")
                btnFilter.Enabled = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Clear the list to repopulate
            lbCarList.Text = "";

            Filter();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods

        private void Filter()
        {
            // Switch to handle what type of filter is selected
            switch (cboFilterType.Text)
            {
                // Return cars based on make selected
                case "Make":
                    foreach (Car c in cars)
                    {
                        if (c.Make == cboFilter.Text)
                            lbCarList.Text += c.GetDisplayText();
                    }
                    break;

                // Return cars based on color selected
                case "Color":
                    foreach (Car c in cars)
                    {
                        if (c.Color == cboFilter.Text)
                            lbCarList.Text += c.GetDisplayText();
                    }
                    break;

                // Return cars in price range selected
                case "Price":
                    switch (cboFilter.SelectedIndex)
                    {
                        case 0: // 0 - 4,999
                            foreach (Car c in cars)
                            {
                                if (c.Price < 5000)
                                    lbCarList.Text += c.GetDisplayText();
                            }
                            break;
                        case 1: // 5,000 - 9,999
                            foreach (Car c in cars)
                            {
                                if (c.Price < 10000 && c.Price >= 5000)
                                    lbCarList.Text += c.GetDisplayText();
                            }
                            break;
                        case 2: // 10,000+
                            foreach (Car c in cars)
                            {
                                if (c.Price >= 10000)
                                    lbCarList.Text += c.GetDisplayText();
                            }
                            break;
                    }
                    break;

                // Return cars in age range selected
                case "Age":
                    DateTime todaysDate = DateTime.Now;

                    switch (cboFilter.SelectedIndex)
                    {
                        case 0: // 0 - 5
                            foreach (Car c in cars)
                            {
                                if (todaysDate.Year - c.Year < 6)
                                    lbCarList.Text += c.GetDisplayText();
                            }
                            break;
                        case 1: // 6 - 10
                            foreach (Car c in cars)
                            {
                                if (todaysDate.Year - c.Year < 11 && todaysDate.Year - c.Year >= 6)
                                    lbCarList.Text += c.GetDisplayText();
                            }
                            break;
                        case 2: // 11+
                            foreach (Car c in cars)
                            {
                                if (todaysDate.Year - c.Year >= 11)
                                    lbCarList.Text += c.GetDisplayText();
                            }
                            break;
                    }
                    break;

                // Return cars based on engine selected
                case "Engine":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Dodge))
                        {
                            Dodge d = (Dodge)c;
                            if (d.Engine == cboFilter.Text)
                                lbCarList.Text += c.GetDisplayText();
                        }
                    }
                    break;

                // Return cars in mileage range selected
                case "Mileage":
                    switch (cboFilter.SelectedIndex)
                    {
                        case 0: // 0 - 49,999
                            foreach (Car c in cars)
                            {
                                if (c.GetType() == typeof(Toyota))
                                {
                                    Toyota t = (Toyota)c;
                                    if (t.Mileage < 50000)
                                        lbCarList.Text += c.GetDisplayText();
                                }
                            }
                            break;
                        case 1: // 50,000 - 99,999
                            foreach (Car c in cars)
                            {
                                if (c.GetType() == typeof(Toyota))
                                {
                                    Toyota t = (Toyota)c;
                                    if (t.Mileage < 100000 && t.Mileage >= 50000)
                                        lbCarList.Text += c.GetDisplayText();
                                }
                            }
                            break;
                        case 2: // 100,000+
                            foreach (Car c in cars)
                            {
                                if (c.GetType() == typeof(Toyota))
                                {
                                    Toyota t = (Toyota)c;
                                    if (t.Mileage >= 100000)
                                        lbCarList.Text += c.GetDisplayText();
                                }
                            }
                            break;
                    }
                    break;

                // Return cars based on transmission selected
                case "Transmission":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Nissan))
                        {
                            Nissan n = (Nissan)c;
                            if (n.Transmission == cboFilter.Text)
                                lbCarList.Text += c.GetDisplayText();
                        }
                    }
                    break;

                // Return cars based on trim selected
                case "Trim":
                    foreach (Car c in cars)
                    {
                        if (c.GetType() == typeof(Ford))
                        {
                            Ford f = (Ford)c;
                            if (f.Trim == cboFilter.Text)
                                lbCarList.Text += c.GetDisplayText();
                        }
                    }
                    break;
            }
        }

        #endregion
    }
}
