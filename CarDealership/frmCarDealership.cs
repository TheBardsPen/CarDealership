using CarDealership.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValidationLibrary;

namespace CarDealership
{
    public partial class frmCarDealership : Form
    {
        // Variables
        public CarList<ICar> cars = new CarList<ICar>();
        public frmLogin loginForm = new frmLogin();

        public frmCarDealership()
        {
            InitializeComponent();
        }

        private void frmCarDealership_Load(object sender, EventArgs e)
        {
            // Display the welcome message
            lblWelcome.Text = $"Hello, {UsersDB.CurrentUser}!";

            // Enable/disable button access if logged in user is not a guest
            if (UsersDB.CurrentUser != "Guest")
            {
                btnProfile.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnProfile.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }

            Validator.LineEnd = "\n"; // testing

            // Load carlist from database on form load
            cars.Load();

            ViewAll();
        }

        #region Event Handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCar addCar = new frmAddCar();// Create an instance of the frmAddCar form

            if (addCar.ShowDialog() == DialogResult.OK) // Show the form as a dialog
            {
                // Get the new car from the addCar form
                ICar newCar = addCar.NewCar;

                // Add the new car to the list
                cars.Add(newCar);

                // Save the list to the database
                cars.Save();

                // Enable delete button
                btnDelete.Enabled = true;

                // Refresh the text box
                ViewAll();
            }
        }

        private void cboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            cboFilter.Items.Clear();
            cboFilter.SelectedIndex = -1;
            cboFilter.Text = "";

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
                    foreach (ICar c in cars)
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
                    foreach (ICar c in cars)
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
                    foreach (ICar c in cars)
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
                    foreach (ICar c in cars)
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
            rTxtBoxDisplayListing.Text = "";

            Filter();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDeleteCar deleteCar = new frmDeleteCar();
            deleteCar.cars = this.cars;
            deleteCar.ShowDialog();

            if (deleteCar.DialogResult == DialogResult.OK)
            {
                cars.RemoveAt((int)deleteCar.Tag);
            }

            if (cars.Count == 0)
                btnDelete.Enabled = false;

            ViewAll();
            cars.Save();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            ViewAll();
        }

        #endregion Event Handlers

        #region Methods

        private void Filter()
        {
            // List of strings to display
            List<string> carDisplay = new List<string>();

            // Switch to handle what type of filter is selected
            switch (cboFilterType.Text)
            {
                // Return cars based on make selected
                case "Make":
                    foreach (ICar c in cars)
                    {
                        if (c.Make == cboFilter.Text)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;

                // Return cars based on color selected
                case "Color":
                    foreach (ICar c in cars)
                    {
                        if (c.Color == cboFilter.Text)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;

                // Return cars in price range selected
                case "Price":
                    carDisplay = PriceFilterSwitch();
                    break;

                // Return cars in age range selected
                case "Age":
                    carDisplay = AgeFilterSwitch();
                    break;

                // Return cars based on engine selected
                case "Engine":
                    foreach (ICar c in cars)
                    {
                        if (c.GetType() == typeof(Dodge))
                        {
                            Dodge d = (Dodge)c;
                            if (d.Engine == cboFilter.Text)
                                carDisplay.Add(c.GetDisplayText());
                        }
                    }
                    break;

                // Return cars in mileage range selected
                case "Mileage":
                    carDisplay = MileageFilterSwitch();
                    break;

                // Return cars based on transmission selected
                case "Transmission":
                    foreach (ICar c in cars)
                    {
                        if (c.GetType() == typeof(Nissan))
                        {
                            Nissan n = (Nissan)c;
                            if (n.Transmission == cboFilter.Text)
                                carDisplay.Add(c.GetDisplayText());
                        }
                    }
                    break;

                // Return cars based on trim selected
                case "Trim":
                    foreach (ICar c in cars)
                    {
                        if (c.GetType() == typeof(Ford))
                        {
                            Ford f = (Ford)c;
                            if (f.Trim == cboFilter.Text)
                                carDisplay.Add(c.GetDisplayText());
                        }
                    }
                    break;
            }

            // Add each list item to the text display
            rTxtBoxDisplayListing.Text = string.Join("\n\n", carDisplay);
        }

        /// Filter by price
        private List<string> PriceFilterSwitch()
        {
            // List of strings to display
            List<string> carDisplay = new List<string>();

            switch (cboFilter.SelectedIndex)
            {
                case 0: // 0 - 4,999
                    foreach (ICar c in cars)
                    {
                        if (c.Price < 5000)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;

                case 1: // 5,000 - 9,999
                    foreach (ICar c in cars)
                    {
                        if (c.Price >= 5000 && c.Price < 10000)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;

                case 2: // 10,000+
                    foreach (ICar c in cars)
                    {
                        if (c.Price >= 10000)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;
            }
            return carDisplay;
        }

        /// Filter by age
        private List<string> AgeFilterSwitch()
        {
            // List of strings to display
            List<string> carDisplay = new List<string>();

            DateTime todaysDate = DateTime.Now;

            switch (cboFilter.SelectedIndex)
            {
                case 0: // 0 - 5
                    foreach (ICar c in cars)
                    {
                        if (todaysDate.Year - c.Year < 6)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;

                case 1: // 6 - 10
                    foreach (ICar c in cars)
                    {
                        if (todaysDate.Year - c.Year < 11 && todaysDate.Year - c.Year >= 6)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;

                case 2: // 11+
                    foreach (ICar c in cars)
                    {
                        if (todaysDate.Year - c.Year >= 11)
                            carDisplay.Add(c.GetDisplayText());
                    }
                    break;
            }
            return carDisplay;
        }

        /// Filter by mileage
        private List<string> MileageFilterSwitch()
        {
            // List of strings to display
            List<string> carDisplay = new List<string>();

            switch (cboFilter.SelectedIndex)
            {
                case 0: // 0 - 49,999
                    foreach (ICar c in cars)
                    {
                        if (c.GetType() == typeof(Toyota))
                        {
                            Toyota t = (Toyota)c;
                            if (t.Mileage < 50000)
                                carDisplay.Add(c.GetDisplayText());
                        }
                    }
                    break;

                case 1: // 50,000 - 99,999
                    foreach (ICar c in cars)
                    {
                        if (c.GetType() == typeof(Toyota))
                        {
                            Toyota t = (Toyota)c;
                            if (t.Mileage < 100000 && t.Mileage >= 50000)
                                carDisplay.Add(c.GetDisplayText());
                        }
                    }
                    break;

                case 2: // 100,000+
                    foreach (ICar c in cars)
                    {
                        if (c.GetType() == typeof(Toyota))
                        {
                            Toyota t = (Toyota)c;
                            if (t.Mileage >= 100000)
                                carDisplay.Add(c.GetDisplayText());
                        }
                    }
                    break;
            }
            return carDisplay;
        }

        private void ViewAll()
        {
            // Reset filters
            cboFilter.Text = "Filter By...";
            cboFilterType.Text = "Filter...";
            cboFilter.Enabled = false;
            btnFilter.Enabled = false;

            // Clear textbox
            rTxtBoxDisplayListing.Text = "";

            var sorted = cars.ToList();
            sorted.Sort(); // uses the IComparable interface to sort the list

            // Create text from each car in the saved list
            foreach (var c in sorted)
                rTxtBoxDisplayListing.Text += c.GetDisplayText() + "\n\n";
        }

        #endregion Methods

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loginForm.ClearPassword();
            loginForm.Show();
            this.Close();
        }
    }
}