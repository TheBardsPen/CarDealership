using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarDealership.Interfaces;

namespace CarDealership
{
    public partial class frmProfile: Form
    {
        public frmProfile()
        {
            InitializeComponent();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            lblUsername.Text = UsersDB.CurrentUser;

            lvListings.Items.Clear();

            var carsSnapshot = frmCarDealership.cars.ToList(); // Call first to use LINQ on List<T>

            var listings = carsSnapshot
                                .Where(c => c.PostedBy == UsersDB.CurrentUser)
                                .OrderByDescending(c => c.DateAdded);

            foreach (ICar c in listings)
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

            lvBookmarks.Items.Clear();

            var bookmarks = carsSnapshot
                                .Where(c => UsersDB.UserBookmarkIDs.Contains(c.CarID))
                                .OrderByDescending(c => c.DateAdded);

            foreach (ICar c in bookmarks)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
