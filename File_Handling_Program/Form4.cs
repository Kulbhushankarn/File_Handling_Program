using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Handling_Program
{
    public partial class Form4 : Form
    {
        private DataGridViewRow selectedRow;

        public Form4(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            this.selectedRow = selectedRow;

            PopulateTextBoxes();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            // Update the data in the selected row and the text file (database)
            if (selectedRow != null)
            {
                UpdateRowData();
                UpdateDatabase();

                this.Close();
                MessageBox.Show("Update Successfully!");
            }
            else
            {
                MessageBox.Show("No row selected for update.");
            }
        }

        private void UpdateRowData()
        {
            // Update the data in the selected row
            selectedRow.Cells[1].Value = textBox1.Text; // Prefix
            selectedRow.Cells[2].Value = textBox2.Text; // FirstName
            selectedRow.Cells[3].Value = textBox3.Text; // LastName
            selectedRow.Cells[4].Value = textBox4.Text; // Education
            selectedRow.Cells[5].Value = textBox5.Text; // JoiningDate
            selectedRow.Cells[6].Value = textBox6.Text; // CurrentCompany
            selectedRow.Cells[7].Value = textBox7.Text; // CurrentAddress
            selectedRow.Cells[8].Value = textBox8.Text; // DOB
        }

        private void UpdateDatabase()
        {
            // Update the data in the text file (database)
            string filePath = "C:\\Users\\lenovo\\Downloads\\New Text Document.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                int rowIndex = selectedRow.Index;

                if (rowIndex >= 0 && rowIndex < lines.Length)
                {
                    lines[rowIndex] = $"{textBox1.Text}\t{textBox2.Text}\t{textBox3.Text}\t{textBox4.Text}\t{textBox5.Text}\t{textBox6.Text}\t{textBox7.Text}\t{textBox8.Text}";

                    File.WriteAllLines(filePath, lines);
                }
                else
                {
                    MessageBox.Show("Invalid row index for updating the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating the database: {ex.Message}");
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clear the TextBoxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void PopulateTextBoxes()
        {
            // Populate TextBoxes with data from the selected row
            if (selectedRow != null)
            {
                textBox1.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                textBox2.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                textBox3.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                textBox4.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                textBox5.Text = selectedRow.Cells[5].Value?.ToString() ?? "";
                textBox6.Text = selectedRow.Cells[6].Value?.ToString() ?? "";
                textBox7.Text = selectedRow.Cells[7].Value?.ToString() ?? "";
                textBox8.Text = selectedRow.Cells[8].Value?.ToString() ?? "";
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
