using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCertMVP
{
    public partial class studentInfoLookup : Form
    {
        //initializes variables to store user input
        string studentID = "";
        string studentSched = "";

        public studentInfoLookup()
        {
            InitializeComponent();
        }

        // receive user input as either
        private void scheduleInputBox_TextChanged(object sender, EventArgs e)
        {

            //The entered values will be stored as List of integars.
            List<int> enteredValues = new List<int>();

            int value;

            if (int.TryParse(consoleOutputLabel.Text, out value))
            {
                enteredValues.Add(value);
            }
            else
            {
                //Show error message here.
            }

        }

        // stores user input schedule on btn click
        private void enterScheduleBtn_Click(object sender, EventArgs e)
        {
            studentSched = scheduleInputBox.Text;
        }

        //stores user input ID on btn click
        private void idBtn_Click(object sender, EventArgs e)
        {
            studentID = idInputBox.Text;
        }

        // receive student id input
        private void idInputBox_TextChanged(object sender, EventArgs e)
        {
            string studentID = Console.ReadLine();
        }

        private void FormNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // taking full path of a file
            string strPath = "C:// myfiles//ref//file1.txt";

            // initialize the value of filename
            string filename = null;

            // using the method
            filename = Path.GetFileName(strPath);
            Console.WriteLine("Filename = " + filename);

            Console.ReadLine();
        }

        private void studentEmailSearchBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
