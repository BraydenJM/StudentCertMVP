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
        //change references to variable that grabs and saves to config file
        string studentID = "";
        string studentSched = "";

        //initializes FileHandler object for multiple different processes
        //replace C:\\ with variable that grabs filepath from config file
        FileHandler files = new FileHandler(@"C:\Users\itadmin\Downloads\StudentFiles");
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
        //private void idBtn_Click(object sender, EventArgs e)
        //{
        //    studentID = idInputBox.Text;
        //}

        ////stores user input schedule on btn click
        //private void enterScheduleBtn_Click(object sender, EventArgs e)
        //{
        //    studentSched = scheduleInputBox.Text;
        //}

        // receive student id input
        
        // exits application when user selects Exit button
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // taking full path of a file
            string strPath = "C://myfiles//ref//file1.txt";

            // initialize the value of filename
            string filename = null;

            // using the method
            filename = Path.GetFileName(strPath);
            Console.WriteLine("Filename = " + filename);

            Console.ReadLine();
        }

        private void selectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDirectory selectDirectory = new SelectDirectory();
            selectDirectory.Show();
        }

        private void studentFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForms studentForms = new StudentForms(files);
            studentForms.Show();
        }

        private void overrideQuarterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverrideQuarter overrideQuarter = new OverrideQuarter();
            overrideQuarter.Show();
        }
    }
}
