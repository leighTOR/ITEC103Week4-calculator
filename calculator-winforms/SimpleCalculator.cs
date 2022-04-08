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
        private string lastOperator;

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
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!lblDisplay.Text.Contains("."))
                    lblDisplay.Text = lblDisplay.Text + button.Text;
            }
            else
                lblDisplay.Text = lblDisplay.Text + button.Text;
        }

        /// <summary>
        /// Clicking the operators button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (lblDisplay.Text == "")
                return;

            lblOperator.ResetText();
            lblOperator.Text = button.Text;
            lblFirstNum.Text = lblDisplay.Text;
            lastOperator = button.Text;

            lblDisplay.ResetText();
        }

        /// <summary>
        /// Clicking the equals button to show the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEquals_Click(object sender, EventArgs e)
        {
            double firstNum, secondNum; 
            double result;

            if (lblDisplay.Text == "")
                return;

            double.TryParse(lblFirstNum.Text, out firstNum);
            double.TryParse(lblDisplay.Text, out secondNum);

            switch (lastOperator)
            {
                case "+":
                    result = firstNum + secondNum;
                    lblSecondNum.Text = secondNum.ToString();
                    lblDisplay.Text = result.ToString();
                    break;
                case "-":
                    result = firstNum - secondNum;
                    lblSecondNum.Text = secondNum.ToString();
                    lblDisplay.Text = result.ToString();
                    break;
                case "*":
                    result = firstNum * secondNum;
                    lblSecondNum.Text = secondNum.ToString();
                    lblDisplay.Text = result.ToString();
                    break;
                case "/":
                    result = firstNum / secondNum;
                    lblSecondNum.Text = secondNum.ToString();
                    lblDisplay.Text = result.ToString();
                    break;
            }
            lblEquals.Text = "=";
        }

        /// <summary>
        /// Clicking the AC (All clear) button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAC_Click(object sender, EventArgs e)
        {
            lblDisplay.ResetText();
            lblFirstNum.ResetText();
            lblOperator.ResetText();
            lblSecondNum.ResetText();
            lblEquals.ResetText();
        }
    }
}