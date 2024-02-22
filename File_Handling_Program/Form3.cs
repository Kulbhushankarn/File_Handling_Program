using System;
using System.Windows.Forms;

namespace File_Handling_Program
{
    public partial class Form3 : Form
    {
        private string[] currentData;
        private int currentIndex;

        public Form3()
        {
            InitializeComponent();
            currentData = new string[9];
            currentIndex = -1; 
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

        // Method to set the text of text boxes in Form3
        public void SetTextBoxValues(string[] values)
        {
            
            if (values != null && values.Length >= 9)
            {
                currentData = values;
                currentIndex = 0; 
                UpdateTextBoxes();
                UpdateNavigationButtons(); 
            }
            else
            {
                MessageBox.Show("Invalid data passed to SetTextBoxValues method.");
            }
        }

        private void firstBtn_Click(object sender, EventArgs e)
        {
            if (currentIndex == 0)
            {
                MessageBox.Show("Already at the first record.");
            }
            else if (currentIndex > 0)
            {
                currentIndex = 0;
                UpdateTextBoxes();
                UpdateNavigationButtons();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                UpdateTextBoxes();
                UpdateNavigationButtons();
            }
            else
            {
                MessageBox.Show("Already at the first record.");
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            
            int totalRecords = 10; 

            if (currentIndex < totalRecords - 1)
            {
                currentIndex++;
                UpdateTextBoxes();
                UpdateNavigationButtons();
            }
            else
            {
                MessageBox.Show("Already at the last record.");
            }
        }

        private void lastBtn_Click(object sender, EventArgs e)
        {
            
            int totalRecords = 10; 

            if (currentIndex < totalRecords - 1)
            {
                currentIndex = totalRecords - 1;
                UpdateTextBoxes();
                UpdateNavigationButtons();
            }
            else
            {
                MessageBox.Show("Already at the last record.");
            }
        }

        private void UpdateTextBoxes()
        {
            textBox1.Text = currentData[0];
            textBox2.Text = currentData[1];
            textBox3.Text = currentData[2];
            textBox4.Text = currentData[3];
            textBox5.Text = currentData[4];
            textBox6.Text = currentData[5];
            textBox7.Text = currentData[6];
            textBox8.Text = currentData[7];
            textBox9.Text = currentData[8];
        }

        
        private void UpdateNavigationButtons()
        {
            // Enable or disable buttons based on the current index
            firstBtn.Enabled = currentIndex > 0;
            prevBtn.Enabled = currentIndex > 0;
            nextBtn.Enabled = currentIndex < currentData.Length - 1;
            lastBtn.Enabled = currentIndex < currentData.Length - 1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
