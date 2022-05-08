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
    public partial class StudentDegreeTrackingProgram : Form
    {
        //initializes variables to store user input
        string studentID = "";
        string studentSched = "";

        public StudentDegreeTrackingProgram()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("c:\\");
        }

        //stores user input ID on btn click
        private void idBtn_Click(object sender, EventArgs e)
        {
            studentID = idInputBox.Text;
        }

        //stores user input schedule on btn click
        private void enterScheduleBtn_Click(object sender, EventArgs e)
        {
            studentSched = scheduleInputBox.Text;
        }
    }
}
