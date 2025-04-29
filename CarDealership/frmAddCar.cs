using System;
using System.Windows.Forms;
using YearlyAcademicPlan;

namespace CarDealership
{
    public partial class frmAddCar : Form
    {
        public Car NewCar { get; set; } // Property to hold the new car object

        public frmAddCar()
        {
            InitializeComponent();

        }

        private void frmAddCar_Load(object sender, EventArgs e)
        {
            // Populate the make combo box with car makes
            cboMake.Items.Add("Dodge");
            cboMake.Items.Add("Ford");
            cboMake.Items.Add("Nissan");
            cboMake.Items.Add("Toyota");

            lblModelSpecific.Visible = false;
            txtModelSpecific.Visible = false;

        }

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboMake.SelectedItem != null)
            {
                // Get the selected make from the combo box
                string selectedMake = cboMake.SelectedItem.ToString();

                txtModelSpecific.Visible = true;
                lblModelSpecific.Visible = true;



                switch (selectedMake)
                {
                    case "Dodge":
                        lblModelSpecific.Text = "Engine:";
                        break;
                    case "Ford":
                        lblModelSpecific.Text = "Trim:";
                        break;
                    case "Nissan":
                        lblModelSpecific.Text = "Transmission:";
                        break;
                    case "Toyota":
                        lblModelSpecific.Text = "Mileage:";
                        break;
                    default:
                        lblModelSpecific.Text = "";
                        break;
                }
            }
            else
            {
                lblModelSpecific.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsComplete())
            {
                MessageBox.Show("Please fill in all required fields.", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the values from the form controls
            string make = cboMake.Text;
            string model = txtModel.Text;
            string color = txtColor.Text;
            int year = int.Parse(txtYear.Text);
            int price = int.Parse(txtPrice.Text);
            string modelSpecific = txtModelSpecific.Text;
            DateTime dateAdded = DateTime.Now;

            Car car = null;

            switch (make)
            {
                case "Ford":
                    car = new Ford(make, model, color, year, price, modelSpecific, dateAdded);
                    break;
                case "Dodge":
                    car = new Dodge(make, model, color, year, price, modelSpecific, dateAdded);
                    break;
                case "Nissan":
                    car = new Nissan(make, model, color, year, price, modelSpecific, dateAdded);
                    break;
                case "Toyota":
                    int mileage = int.Parse(modelSpecific); // Assuming mileage is an integer after validation
                    car = new Toyota(make, model, color, year, price, mileage, dateAdded);
                    break;
                default:
                    MessageBox.Show("Invalid make selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            this.NewCar = car;

            this.DialogResult = DialogResult.OK;
        }

        #endregion

        private bool IsComplete()
        {
            if (Validation.IsComboSelected("'Make:'", cboMake) &&
                Validation.IsTextboxString("'Model:'", txtModel) &&
                Validation.IsTextboxString("'Color:'", txtColor) &&
                Validation.IsTextboxInt("'Year:'", txtYear) &&
                Validation.IsTextboxInt("'Price:'", txtPrice))
            {
                if (cboMake.Text == "Toyota" && Validation.IsTextboxInt($"'{lblModelSpecific}'", txtModelSpecific))
                    return true;
                else if (Validation.IsTextboxString($"'{lblModelSpecific}'", txtModelSpecific))
                    return true;
            }

            return false;
        }
    }
}
