using System;
using System.IO;
using System.Windows.Forms;

namespace File_Handling_Program
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddUserToFile();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void AddUserToFile()
        {
            try
            {
                // Get the values from the Controls
                string prefix = textBox1.Text;
                string firstName = textBox2.Text;
                string middleName = textBox3.Text;
                string lastName = textBox4.Text;
                string education = educationComboBox.SelectedItem?.ToString() ?? string.Empty;
                string joiningDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string currentCompany = textBox6.Text;
                string currentAddress = textBox7.Text;
                string dob = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                // Create a binary writer
                using (BinaryWriter writer = new BinaryWriter(File.Open("C:\\Users\\lenovo\\Downloads\\New Text Document.bin", FileMode.Append)))
                {
                    // Write data in binary format
                    writer.Write(prefix);
                    writer.Write(firstName);
                    writer.Write(middleName);
                    writer.Write(lastName);
                    writer.Write(education);
                    writer.Write(joiningDate);
                    writer.Write(currentCompany);
                    writer.Write(currentAddress);
                    writer.Write(dob);
                }

                // Clear the controls after writing
                ClearControls();

                MessageBox.Show("User added successfully in binary format.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ClearControls()
        {
            // Clear the TextBoxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();

            // Reset DateTimePicker values
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
