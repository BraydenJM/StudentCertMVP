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

        private void scheduleInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        //stores user input schedule on btn click
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
    }
}
