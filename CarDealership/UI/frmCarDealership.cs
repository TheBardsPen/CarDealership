using CarDealership.Interfaces;
using System;
using System.Linq;
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

        #region Event Handlers

        #region Buttons

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Clear the list to repopulate
            //rTxtBoxDisplayListing.Text = "";

            Filter();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            ViewAll();
        }

        #endregion

        #region ComboBox

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

        private void DEBUG_FilterType_SelectionChange()
        {

        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilter.Text != "Filter...")
                btnFilter.Enabled = true;
        }

        #endregion

        #region MenuStrip

        private void msiLogout_Click(object sender, EventArgs e)
        {
            loginForm.ClearPassword();
            loginForm.Show();
            this.Close();
        }

        private void msiLogin_Click(object sender, EventArgs e)
        {
            loginForm.ClearForm();
            loginForm.Show();
            this.Close();
        }

        private void msiAddCar_Click(object sender, EventArgs e)
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

                // Refresh the text box
                ViewAll();
            }
        }

        private void msiDeleteCar_Click(object sender, EventArgs e)
        {
            frmDeleteCar deleteCar = new frmDeleteCar();
            deleteCar.cars = this.cars;
            deleteCar.ShowDialog();

            if (deleteCar.DialogResult == DialogResult.OK)
            {
                cars.RemoveAt((int)deleteCar.Tag);
            }

            ViewAll();
            cars.Save();
        }

        private void msiProfile_Click(object sender, EventArgs e)
        {
            frmProfile profileForm = new frmProfile();

            profileForm.ShowDialog();
        }

        #endregion

        #region Automatic

        private void frmCarDealership_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }

        private void frmCarDealership_Load(object sender, EventArgs e)
        {
            // Display the welcome message
            //lblWelcome.Text = $"Hello, {UsersDB.CurrentUser}!";

            // Enable/disable button access if logged in user is not a guest
            if (UsersDB.CurrentUser != "Guest")
            {
                msiAddCar.Enabled = true;
                msiDeleteCar.Enabled = true;
                msiBookmarks.Enabled = true;
                msiLogout.Enabled = true;
                msiProfile.Enabled = true;
                msiLogin.Enabled = false;
            }
            else
            {
                msiAddCar.Enabled = false;
                msiAddCar.ToolTipText = "Must be logged in to list cars.";
                msiDeleteCar.Enabled = false;
                msiDeleteCar.ToolTipText = "Must be logged in to remove cars.";
                msiBookmarks.Enabled = false;
                msiBookmarks.ToolTipText = "Must be logged in to bookmark cars.";
                msiLogout.Enabled = false;
                msiProfile.Enabled = false;
                msiLogin.Enabled = true;
            }

            Validator.LineEnd = "\n"; // testing

            // Load carlist from database on form load
            cars.Load();

            //PopulateListView(cars);

            ViewAll();
        }

        #endregion

        #endregion Event Handlers

        #region Methods

        private void Filter()
        {
            // List of strings to display
            List<string> carDisplay = new List<string>();

            lvListings.Items.Clear();

            // Switch to handle what type of filter is selected
            switch (cboFilterType.Text)
            {
                // Return cars based on make selected
                case "Make":
                    FilterMake(cboFilter.Text);
                    break;

                // Return cars based on color selected
                case "Color":
                    FilterColor(cboFilter.Text);
                    break;

                // Return cars in price range selected
                case "Price":
                    //FilterPrice
                    break;

                // Return cars in age range selected
                case "Age":
                    //FilterAge
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
            //rTxtBoxDisplayListing.Text = string.Join("\n\n", carDisplay);
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

            // Create text from each car in the saved list
            lvListings.Items.Clear();

            foreach (ICar c in cars)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = c;
                lvi.Text = c.Make;
                lvi.SubItems.Add(c.Model);
                lvi.SubItems.Add(c.Year.ToString());
                lvi.SubItems.Add(c.Color);
                lvi.SubItems.Add(c.Price.ToString("c"));
                lvi.SubItems.Add(c.DateAdded.ToShortDateString());
                lvListings.Items.Add(lvi);
            }
        }

        /*private void PopulateListView(CarList<ICar> filteredList)
        {
            lvListings.Items.Clear();

            foreach (ICar c in filteredList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = c;
                lvi.Text = c.Make;
                lvi.SubItems.Add(c.Model);
                lvi.SubItems.Add(c.Year.ToString());
                lvi.SubItems.Add(c.Color);
                lvi.SubItems.Add(c.Price.ToString("c"));
                lvi.SubItems.Add(c.DateAdded.ToShortDateString());
                lvListings.Items.Add(lvi);
            }
        }*/

        #endregion Methods

        private void FilterMake(string make)
        {
            var carsSnapshot = cars.ToList();

            var filteredList = carsSnapshot
                                .Where(c => c.Make == make)
                                .OrderBy(c => c.DateAdded);

            foreach (ICar c in filteredList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = c;
                lvi.Text = c.Make;
                lvi.SubItems.Add(c.Model);
                lvi.SubItems.Add(c.Year.ToString());
                lvi.SubItems.Add(c.Color);
                lvi.SubItems.Add(c.Price.ToString("c"));
                lvi.SubItems.Add(c.DateAdded.ToShortDateString());
                lvListings.Items.Add(lvi);
            }
        }

        private void FilterColor(string color)
        {
            var carsSnapshot = cars.ToList();

            var filteredList = carsSnapshot
                                .Where(c => c.Color == color)
                                .OrderBy(c => c.DateAdded);

            foreach (var c in filteredList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = c;
                lvi.Text = c.Make;
                lvi.SubItems.Add(c.Model);
                lvi.SubItems.Add(c.Year.ToString());
                lvi.SubItems.Add(c.Color);
                lvi.SubItems.Add(c.Price.ToString("c"));
                lvi.SubItems.Add(c.DateAdded.ToShortDateString());
                lvListings.Items.Add(lvi);
            }
        }

        private void FilterAge(int minAge, int maxAge)
        {
            var filteredList = cars
                                .ToList() // Call first to use LINQ on List<T>
                                .Where(c => c.Year <= DateTime.Now.Year - minAge && c.Year >= DateTime.Now.Year)
                                .OrderBy(c => c.DateAdded);

            foreach (var c in filteredList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = c;
                lvi.Text = c.Make;
                lvi.SubItems.Add(c.Model);
                lvi.SubItems.Add(c.Year.ToString());
                lvi.SubItems.Add(c.Color);
                lvi.SubItems.Add(c.Price.ToString("c"));
                lvi.SubItems.Add(c.DateAdded.ToShortDateString());
                lvListings.Items.Add(lvi);
            }
        }

        private void FilterPrice(decimal minPrice, decimal maxPrice)
        {
            var filteredList = cars
                                .ToList() // Call first to use LINQ on List<T>
                                .Where(c => c.Price > minPrice && c.Price < maxPrice)
                                .OrderBy(c => c.DateAdded);

            foreach (var c in filteredList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = c;
                lvi.Text = c.Make;
                lvi.SubItems.Add(c.Model);
                lvi.SubItems.Add(c.Year.ToString());
                lvi.SubItems.Add(c.Color);
                lvi.SubItems.Add(c.Price.ToString("c"));
                lvi.SubItems.Add(c.DateAdded.ToShortDateString());
                lvListings.Items.Add(lvi);
            }
        }
    }
}