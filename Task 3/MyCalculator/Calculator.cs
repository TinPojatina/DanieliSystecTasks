using System;
using System.Windows.Forms;
using System.Data;

namespace MyCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        //
        // Event handler for number buttons
        private void Zero_Click(object sender, EventArgs e)
        {
            AppendText("0");
        }

        private void One_Click(object sender, EventArgs e)
        {
            AppendText("1");
        }

        private void Two_Click(object sender, EventArgs e)
        {
            AppendText("2");
        }

        private void Three_Click(object sender, EventArgs e)
        {
            AppendText("3");
        }

        private void Four_Click(object sender, EventArgs e)
        {
            AppendText("4");
        }

        private void Five_Click(object sender, EventArgs e)
        {
            AppendText("5");
        }

        private void Six_Click(object sender, EventArgs e)
        {
            AppendText("6");
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            AppendText("7");
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            AppendText("8");
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            AppendText("9");
        }

        private void DotBtn_Click(object sender, EventArgs e)
        {
            AppendText(".");
        }


        //
        // Functionality event handlers
        private void MultiplyBtn_Click(object sender, EventArgs e)
        {
            AppendText("*");
        }

        private void EqualBtn_Click(object sender, EventArgs e)
        {
            // Evaluate the expression and display the result in the text box
            txtBox.Text = EvaluateExpression(txtBox.Text).ToString();
        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {
            AppendText("/");
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            AppendText("-");
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Clear the text box by setting the value to "0"
            txtBox.Text = "0";
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AppendText("+");
        }

        private void AppendText(string text)
        {
            if (txtBox.Text == "0" && text != ".")
            {
                // If the text box contains "0" and the entered text is not ".", replace the value with the entered text
                txtBox.Text = text;
            }
            else
            {
                // Otherwise, append the text to the existing text in the text box
                txtBox.Text += text;
            }
        }

        // Evaluates the mathematical expression and returns the result as a double
        private static double EvaluateExpression(string expression)
        {
            // Create a data table to perform the evaluation
            DataTable table = new DataTable();

            // Add a column to the table with the expression to evaluate
            table.Columns.Add("expression", string.Empty.GetType(), expression);

            // Create a new row in the table
            DataRow row = table.NewRow();

            // Add the row to the table
            table.Rows.Add(row);

            // Parse and return the expression result as a double
            return double.Parse((string)row["expression"]);
        }
    }
}
