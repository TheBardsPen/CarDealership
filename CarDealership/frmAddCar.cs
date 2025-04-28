using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YearlyAcademicPlan;

namespace CarDealership
{
    public partial class frmAddCar: Form
    {
  
        public frmAddCar()
        {
            InitializeComponent();
 
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            throw new NotImplementedException();
        }

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
