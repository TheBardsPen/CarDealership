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
using CarDealership.UI;

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

            RefreshListings();

            RefreshBookmarks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult firstConfrim = MessageBox.Show(
                                                    "Are you sure you wish to delete your user account?", "Delete Account",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (firstConfrim == DialogResult.Yes)
            {
                DialogResult secondConfirm = MessageBox.Show(
                                                    "This action is irreversible. You will lose all active listings and bookmarks.", "Delete Account",
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (secondConfirm == DialogResult.OK)
                    DeleteAccount();
            }
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshListings()
        {
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
        }

        private void RefreshBookmarks()
        {
            lvBookmarks.Items.Clear();

            var carsSnapshot = frmCarDealership.cars.ToList(); // Call first to use LINQ on List<T>

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
                lvBookmarks.Items.Add(lvi);
            }
        }

        private void DeleteAccount()
        {
            var carsSnapshot = frmCarDealership.cars.ToList(); // Call first to use LINQ on List<T>

            var listings = carsSnapshot
                                .Where(c => c.PostedBy == UsersDB.CurrentUser && c.IsSold == false);

            foreach (var listing in listings)
            {
                frmCarDealership.cars.Remove(listing);
            }

            frmCarDealership.cars.Save();

            UsersDB.users.Remove(UsersDB.CurrentUser);
            UsersDB.SaveUsers(UsersDB.users);

            // Using "Abort" to prevent accidental ok, yes, no, etc.
            this.DialogResult = DialogResult.Abort;

            this.Close();
        }

        private void lvListings_DoubleClick(object sender, EventArgs e)
        {
            if (lvListings.SelectedItems != null)
            {
                frmListing frm  = new frmListing((Car)lvListings.SelectedItems[0].Tag);

                frm.ShowDialog();
            }
        }

        private void lvBookmarks_DoubleClick(object sender, EventArgs e)
        {
            if (lvListings.SelectedItems != null)
            {
                frmListing frm = new frmListing((Car)lvListings.SelectedItems[0].Tag);

                frm.ShowDialog();
            }
        }
    }
}
