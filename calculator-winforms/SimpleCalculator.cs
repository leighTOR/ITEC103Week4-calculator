using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator_winforms
{
    public partial class Calculator : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clicking the numbers and point buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNumber_click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
            {
                txtDisplay.Clear();
            }

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + button.Text;
                }
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + button.Text;
            }
        }

        /// <summary>
        /// Clicking the operators button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnEquals.PerformClick();
                operationPerformed = button.Text;
                lblDisplay.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(txtDisplay.Text);
                lblDisplay.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        /// <summary>
        /// Clicking the equals button to show the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEquals_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (resultValue / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(txtDisplay.Text);
            lblDisplay.Text = "";
        }

        /// <summary>
        /// Clicking the AC (All clear) button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0"; // returning the textbox to 0
            lblDisplay.Text = ""; // returnning the label display to null
        }
    }
}