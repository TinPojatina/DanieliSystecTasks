using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            if(txtBox.Text == "0")
            {
                txtBox.Text = "0";
            }
            else
            {
                txtBox.Text += "0";
            }
        }

        private void DotBtn_Click(object sender, EventArgs e)
        {
            if (txtBox.Text.Contains("."))
            {
                txtBox.Text = ".";
            }
            else
            {
                txtBox.Text += ".";
            }
        }

        private void MultiplyBtn_Click(object sender, EventArgs e)
        {

        }

        private void EqualBtn_Click(object sender, EventArgs e)
        {

        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {

        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

        }

        private void One_Click(object sender, EventArgs e)
        {
            if(txtBox.Text == "0")
            {
                txtBox.Text ="1";
            }
            else
            {
                txtBox.Text += "1";
            }
        }

        private void Two_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "2";
            }
            else
            {
                txtBox.Text += "2";
            }
        }

        private void Three_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "3";
            }
            else
            {
                txtBox.Text += "3";
            }
        }

        private void Four_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "4";
            }
            else
            {
                txtBox.Text += "4";
            }
        }

        private void Five_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "5";
            }
            else
            {
                txtBox.Text += "5";
            }
        }

        private void Six_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "6";
            }
            else
            {
                txtBox.Text += "6";
            }
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "7";
            }
            else
            {
                txtBox.Text += "7";
            }
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "8";
            }
            else
            {
                txtBox.Text += "8";
            }
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            if (txtBox.Text == "0")
            {
                txtBox.Text = "9";
            }
            else
            {
                txtBox.Text += "9";
            }
        }
    }
}
