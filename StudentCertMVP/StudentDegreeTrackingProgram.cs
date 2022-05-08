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
            studentInfoLookup stuInfoLookup = new studentInfoLookup();
            stuInfoLookup.Show(this);

            // opens file browser from menu to allow opening file from local machine
            var FD = new System.Windows.Forms.OpenFileDialog(); // file opens in "openFileDialog" box
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FD.FileName;

                System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);

                //OR

                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                //etc
            }
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

        // receive student id input
        private void idInputBox_TextChanged(object sender, EventArgs e)
        {
            string studentID = Console.ReadLine();
        }
        
        // exits application when user selects Exit button
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
