using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxSurname.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) || birthDatePicker.Value == DateTimePicker.MinimumDateTime)
                {
                    MessageBox.Show("Lütfen bilgilerinizi tamamen doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    updateButtons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button0.Enabled = true;
            buttonPoint.Enabled = true;
            buttonAdd.Enabled = true;
            buttonSubtract.Enabled = true;
            buttonMultiple.Enabled = true;
            buttonDivide.Enabled = true;
            buttonCalculate.Enabled = true;
        }

        private double EvaluateExpression(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);

            DataRow row = table.NewRow();
            table.Rows.Add(row);

            return double.Parse((string)row["expression"]);
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Lütfen adınızı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
            }
        }
        private void textBoxSurname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Lütfen soyadınızı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSurname.Focus();
            }
        }
        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Lütfen e-posta adresinizi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
            }
        }
        private void birthDatePicker_Leave(object sender, EventArgs e)
        {
            if (birthDatePicker.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("Lütfen doğum tarihinizi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                birthDatePicker.Focus();
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxInput.Text))
            {
                double result = 0;
                string expression = textBoxInput.Text;

                if (IsInputValid(textBoxInput.Text))
                {
                    result = EvaluateExpression(expression);
                }
                else
                {
                    MessageBox.Show("Lütfen işleminizi doğru giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                textBoxResult.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen hesaplanacak değerleri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Girilen işlemin (sayı)(operatör)(sayı) şeklinde olup olmadığını kontrol eder.
        private bool IsInputValid(string input)
        {
            string pattern = @"^\d+(\.\d+)?\s*[-+*/]\s*\d+(\.\d+)?$";
            return Regex.IsMatch(input, pattern);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "0";
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxInput.Text) && (textBoxInput.Text[textBoxInput.Text.Length - 1]) != '.')
            {
                textBoxInput.Text += ".";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxInput.Text.Length > 0)
            {
                textBoxInput.Text = textBoxInput.Text.Remove(textBoxInput.Text.Length - 1);
            }
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = "";
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                textBoxResult.Text = "0";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "+";
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "-";
        }

        private void buttonMultiple_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "*";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "/";
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.github.com/atakavuncu");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
