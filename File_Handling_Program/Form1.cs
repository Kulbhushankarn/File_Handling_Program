using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace File_Handling_Program
{
    public partial class Form1 : Form
    {
        private int serialNumberCounter = 1; // Counter for dynamic serial numbers
        private bool isUpdateButtonEnabled = false;
        private bool isDeleteButtonEnabled = false;

        public Form1()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.ShowDialog();
            LoadDataIntoDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if any cell is selected
            if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
            {
                // Enable the buttons
                button2.Enabled = true; // Update button
                button3.Enabled = true; // Delete button


            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Check if any cell is selected
                if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
                {
                    // Get the selected row index
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    // Check if the row index is valid
                    if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                    {
                        // Get the values of all cells in the selected row
                        string[] rowValues = new string[dataGridView1.Columns.Count];
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            // Check if the cell value is not null
                            rowValues[i] = dataGridView1[i, rowIndex].Value?.ToString() ?? string.Empty;
                        }

                        // Create an Instance of Form3
                        Form3 thirdForm = new Form3();

                        // Call the SetTextBoxValues method in Form3 and pass the row values
                        thirdForm.SetTextBoxValues(rowValues);

                        // Show Form3
                        thirdForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid row index.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a cell before double-clicking.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Method to load data into DataGridView
        private void LoadDataIntoDataGridView()
        {
            try
            {
                string filePath = "C:\\Users\\lenovo\\Downloads\\New Text Document.txt";

                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Clear existing rows
                    dataGridView1.Rows.Clear();

                    foreach (string line in lines)
                    {
                        // Split by any whitespace characters (tabs, spaces)
                        string[] values = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (values.Length >= 8) // Assuming there are 8 columns excluding the serial number
                        {
                            int rowIndex = dataGridView1.Rows.Add();

                            // Set the serial number dynamically
                            dataGridView1.Rows[rowIndex].Cells[0].Value = serialNumberCounter.ToString();
                            serialNumberCounter++;

                            // Set cell values for the other columns
                            dataGridView1.Rows[rowIndex].Cells[1].Value = values[0]; // Prefix
                            dataGridView1.Rows[rowIndex].Cells[2].Value = values[1]; // FirstName
                            dataGridView1.Rows[rowIndex].Cells[3].Value = values[2]; // LastName
                            dataGridView1.Rows[rowIndex].Cells[4].Value = values[3]; // Education
                            dataGridView1.Rows[rowIndex].Cells[5].Value = values[4]; // JoiningDate
                            dataGridView1.Rows[rowIndex].Cells[6].Value = values[5]; // CurrentCompany
                            dataGridView1.Rows[rowIndex].Cells[7].Value = values[6]; // CurrentAddress
                            dataGridView1.Rows[rowIndex].Cells[8].Value = values[7]; // DOB
                        }
                        else
                        {
                            MessageBox.Show($"Invalid line format: {line}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"File not found: {filePath}");
                }

                button2.Enabled = false;
                button3.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                Form4 fourthForm = new Form4(selectedRow);
                fourthForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row before updating.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete button clicked
            if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Update the serial number after deletion
                UpdateSerialNumbers();
            }
            else
            {
                MessageBox.Show("Please select a row before deleting.");
            }
        }

        private void UpdateSerialNumbers()
        {
            // Update serial numbers in the DataGridView
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }

            // Reset the serialNumberCounter to the last index
            serialNumberCounter = dataGridView1.Rows.Count + 1;
        }
    }
}
