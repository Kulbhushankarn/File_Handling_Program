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
    public partial class Form1 : Form
    {
        private int serialNumberCounter = 1;
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
            if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
            {
                // Enable the buttons
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells != null && dataGridView1.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                    {
                        string[] rowValues = new string[dataGridView1.Columns.Count];
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            rowValues[i] = dataGridView1[i, rowIndex].Value?.ToString() ?? string.Empty;
                        }

                        Form3 thirdForm = new Form3();
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
                string filePath = "C:\\Users\\lenovo\\Downloads\\New Text Document.bin";

                if (File.Exists(filePath))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        dataGridView1.Rows.Clear();
                        serialNumberCounter = 1;

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            // Read data in binary format
                            string prefix = reader.ReadString();
                            string firstName = reader.ReadString();
                            string middleName = reader.ReadString();
                            string lastName = reader.ReadString();
                            string education = reader.ReadString();
                            string joiningDate = reader.ReadString();
                            string currentCompany = reader.ReadString();
                            string currentAddress = reader.ReadString();
                            string dob = reader.ReadString();

                            // Add data to DataGridView
                            int rowIndex = dataGridView1.Rows.Add();
                            dataGridView1.Rows[rowIndex].Cells[0].Value = serialNumberCounter.ToString();
                            serialNumberCounter++;
                            dataGridView1.Rows[rowIndex].Cells[1].Value = prefix;
                            dataGridView1.Rows[rowIndex].Cells[2].Value = firstName;
                            dataGridView1.Rows[rowIndex].Cells[3].Value = lastName;
                            dataGridView1.Rows[rowIndex].Cells[4].Value = education;
                            dataGridView1.Rows[rowIndex].Cells[5].Value = joiningDate;
                            dataGridView1.Rows[rowIndex].Cells[6].Value = currentCompany;
                            dataGridView1.Rows[rowIndex].Cells[7].Value = currentAddress;
                            dataGridView1.Rows[rowIndex].Cells[8].Value = dob;
                        }
                    }

                    button2.Enabled = false;
                    button3.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"File not found: {filePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void DeleteRecordFromFile(int rowIndex)
        {
            string filePath = "C:\\Users\\lenovo\\Downloads\\New Text Document.bin";

            try
            {
                List<string[]> records = new List<string[]>();

                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        // Read data in binary format
                        string prefix = reader.ReadString();
                        string firstName = reader.ReadString();
                        string middleName = reader.ReadString();
                        string lastName = reader.ReadString();
                        string education = reader.ReadString();
                        string joiningDate = reader.ReadString();
                        string currentCompany = reader.ReadString();
                        string currentAddress = reader.ReadString();
                        string dob = reader.ReadString();

                        records.Add(new string[] { prefix, firstName, middleName, lastName, education, joiningDate, currentCompany, currentAddress, dob });
                    }
                }

                if (rowIndex >= 0 && rowIndex < records.Count)
                {
                    // Remove the selected record
                    records.RemoveAt(rowIndex);

                    // Write the updated records back to the binary file
                    using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                    {
                        foreach (string[] record in records)
                        {
                            // Write data in binary format
                            writer.Write(record[0]);
                            writer.Write(record[1]);
                            writer.Write(record[2]);
                            writer.Write(record[3]);
                            writer.Write(record[4]);
                            writer.Write(record[5]);
                            writer.Write(record[6]);
                            writer.Write(record[7]);
                            writer.Write(record[8]);
                        }
                    }

                    // Remove the row from the DataGridView
                    dataGridView1.Rows.RemoveAt(rowIndex);

                    // Update serial numbers
                    UpdateSerialNumbers();

                    MessageBox.Show("Record deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Invalid row index for deletion.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record from file: {ex.Message}");
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
                try
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    string serialNumber = dataGridView1.Rows[rowIndex].Cells[0].Value?.ToString();

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete record with Serial Number {serialNumber}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Delete the record from the file
                        DeleteRecordFromFile(rowIndex);

                        // Update serial numbers
                        UpdateSerialNumbers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a row before deleting.");
            }
        }

        private void UpdateSerialNumbers()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }

            serialNumberCounter = dataGridView1.Rows.Count + 1;
        }
    }
}
