using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidationLibrary
{
    /// <summary>
    /// Class <c>Validation</c> contains methods that check for various types of user input to prevent errors.
    /// </summary>
    public static class Validator
    {
        private static string requiredInt = " should be a valid integer value.";
        private static string requiredDecimal = " should be a valid decimal value.";
        private static string requiredString = " is a required field.";
        private static string requiredComboField = " is a required field. Please make a selection.";

        /// <summary>
        /// The character sequence to terminate each line
        /// in the validation message.
        /// </summary>
        public static string LineEnd { get; set; } = "\n";

        #region Text Box

        /// <summary>
        /// Used to verify a textbox is not empty.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <returns>True if textbox is not empty, false and an error message if it is empty.</returns>
        public static bool IsTextboxString(string name, TextBox box)
        {
            if (box.Text == "")
            {
                MessageBox.Show(name + requiredString, "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Used to verify if a textbox can be converted to an integer.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <returns>True if textbox can be converted to an integer, false and an error message if not.</returns>
        public static bool IsTextboxInt(string name, TextBox box)
        {
            if (!int.TryParse(box.Text, out _))
            {
                MessageBox.Show(name + requiredInt, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Used to verify if a textbox can be converted to a decimal.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <returns>True if textbox can be converted to an decimal, false and an error message if not.</returns>
        public static bool IsTextboxDecimal(string name, TextBox box)
        {
            if (!decimal.TryParse(box.Text, out _))
            {
                MessageBox.Show(name + requiredDecimal, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Combo Box

        /// <summary>
        /// Used to verify if a non-typeable dropdown has a selected value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="box"></param>
        /// <returns>True if drowpdown has been selected, false and an error message if it is left unselected.</returns>
        public static bool IsComboSelected(string name, ComboBox box)
        {
            if (box.SelectedItem == null)
            {
                MessageBox.Show(name + requiredComboField, "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
}
