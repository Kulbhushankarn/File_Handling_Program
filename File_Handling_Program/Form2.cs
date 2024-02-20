using System;
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
                string joiningDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Format the date as needed
                string currentCompany = textBox6.Text;
                string currentAddress = textBox7.Text;
                string dob = dateTimePicker2.Value.ToString("yyyy-MM-dd"); // Format the date as needed

                
                string userData = $"{prefix}\t{firstName}\t{middleName}\t{lastName}\t{education}\t{joiningDate}\t{currentCompany}\t{currentAddress}\t{dob}";

                
                string filePath = "C:\\Users\\lenovo\\Downloads\\New Text Document.txt";

                
                System.IO.File.AppendAllText(filePath, userData + Environment.NewLine);

                
                ClearControls();

                MessageBox.Show("User added successfully.");
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
