using System;
using System.Diagnostics.Contracts;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationLibrary;

namespace ValidationLibraryTest
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void IsTextboxString_True()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "String";

            bool expected = true;
            var result = Validator.IsTextboxString("Test", txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTextboxString_False()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "";

            bool expected = false;
            var result = Validator.IsTextboxString("Test", txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTextboxInt_True()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "15";

            bool expected = true;
            var result = Validator.IsTextboxInt("Test", txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTextboxInt_False()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "String";

            bool expected = false;
            var result = Validator.IsTextboxInt("Test", txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTextboxDecimal_True()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "15.5";

            bool expected = true;
            var result = Validator.IsTextboxDecimal("Test", txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsTextboxDecimal_False()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "String";

            bool expected = false;
            var result = Validator.IsTextboxDecimal("Test", txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsComboSelected_True()
        {
            ComboBox cboBox = new ComboBox();
            cboBox.Items.Add("Hello World!");
            cboBox.SelectedIndex = 0;

            bool expected = true;
            var result = Validator.IsComboSelected("Test", cboBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsComboSelected_False()
        {
            ComboBox cboBox = new ComboBox();
            cboBox.Items.Add("Hello World!");
            cboBox.SelectedItem = null;

            bool expected = false;
            var result = Validator.IsComboSelected("Test", cboBox);
            Assert.AreEqual(expected, result);
        }
    }
}
