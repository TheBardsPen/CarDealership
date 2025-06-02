using CarDealership.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using ValidationLibrary;
using System.Drawing;

namespace CarDealership
{
    public partial class frmCarDealership : Form
    {
        // Variables
        public CarList<ICar> cars = new CarList<ICar>();
        public frmLogin loginForm = new frmLogin();
        private int minTracker = 0;
        private int maxTracker = 0;

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
            btnFilter.Enabled = false;

            cboFilter.Items.Clear();
            cboFilter.SelectedIndex = -1;
            cboFilter.Text = "";
            cboFilter.Enabled = false;

            trackMin.Enabled = false;
            trackMax.Enabled = false;

            lblFilterMin.Visible = false;
            lblFilterMax.Visible = false;

            var carsSnapshot = cars.ToList();

            switch (cboFilterType.Text)
            {
                case "Make":
                    var makeArray = carsSnapshot
                                        .Select(c => c.Make);

                    cboFilter.Items.AddRange(makeArray.Distinct().ToArray());

                    cboFilter.Enabled = true;

                    break;
                case "Color":
                    var colorArray = carsSnapshot
                                        .Select(c => c.Color);

                    cboFilter.Items.AddRange(colorArray.Distinct().ToArray());

                    cboFilter.Enabled = true;

                    break;
                case "Price":
                    btnFilter.Enabled = true;

                    trackMin.Enabled = true;
                    trackMax.Enabled = true;

                    trackMin.Value = 0;
                    trackMax.Value = 20;

                    minTracker = 0;
                    maxTracker = 100000;

                    lblFilterMin.Visible = true;
                    lblFilterMax.Visible = true;

                    lblFilterMin.Text = $"Min Price: {minTracker.ToString("c")}";
                    lblFilterMax.Text = $"Max Price: {maxTracker.ToString("c")}";

                    break;
                case "Age":
                    btnFilter.Enabled = true;

                    trackMin.Enabled = true;
                    trackMax.Enabled = true;

                    trackMin.Value = 0;
                    trackMax.Value = 20;

                    minTracker = 0;
                    maxTracker = 40;

                    lblFilterMin.Visible = true;
                    lblFilterMax.Visible = true;

                    lblFilterMin.Text = $"Min Age: {minTracker}";
                    lblFilterMax.Text = $"Max Age: {maxTracker}";

                    break;
                default:
                    cboFilter.Enabled = false;
                    break;
            }
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
                    FilterPrice(minTracker, maxTracker);
                    break;

                // Return cars in age range selected
                case "Age":
                    FilterAge(minTracker, maxTracker);
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

            trackMin.Enabled = false;
            trackMax.Enabled = false;

            lblFilterMin.Visible = false;
            lblFilterMax.Visible = false;

            // Create text from each car in the saved list
            lvListings.Items.Clear();

            var carsSnapshot = cars.ToList(); // Call first to use LINQ on List<T>

            var filteredList = carsSnapshot
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

        #endregion Methods

        private void FilterMake(string make)
        {
            var carsSnapshot = cars.ToList(); // Call first to use LINQ on List<T>

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
            var carsSnapshot = cars.ToList(); // Call first to use LINQ on List<T>

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
            var carsSnapshot = cars.ToList(); // Call first to use LINQ on List<T>

            var filteredList = carsSnapshot
                                .Where(c => c.Year <= DateTime.Now.Year - minAge && c.Year >= DateTime.Now.Year - maxAge)
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
            var carsSnapshot = cars.ToList(); // Call first to use LINQ on List<T>

            var filteredList = carsSnapshot
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

        private void trackMin_Scroll(object sender, EventArgs e)
        {
            if (cboFilterType.Text == "Price")
            {
                minTracker = trackMin.Value * 5000;

                lblFilterMin.Text = $"Min Price: {minTracker.ToString("c")}";
            }
            else if (cboFilterType.Text == "Age")
            {
                minTracker = trackMin.Value * 2;

                lblFilterMin.Text = $"Min Age: {minTracker}";
            }

            trackMin.Maximum = trackMax.Value - 1;
            trackMax.Minimum = trackMin.Value + 1;
        }

        private void trackMax_Scroll(object sender, EventArgs e)
        {
            if (cboFilterType.Text == "Price")
            {
                maxTracker = trackMax.Value * 5000;

                lblFilterMax.Text = $"Max Price: {maxTracker.ToString("c")}";
            }
            else if (cboFilterType.Text == "Age")
            {
                maxTracker = trackMax.Value * 2;

                lblFilterMax.Text = $"Max Age: {maxTracker}";
            }

            trackMax.Minimum = trackMin.Value + 1;
            trackMin.Maximum = trackMax.Value - 1;
        }
    }
}