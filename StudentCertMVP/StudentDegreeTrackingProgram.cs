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
        FileHandler files { get; set; }
        classRegex IDcheck = new classRegex();
        public StudentDegreeTrackingProgram()
        {
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\config.txt"))
            {
                File.WriteAllTextAsync("config.txt", string.Empty);
            }
            this.files = new FileHandler(File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\config.txt"));

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
            //selectDirectory.FormClosing += new FormClosingEventHandler(this.SelectDirectory_FormClosing);
            selectDirectory.Show();
        }

        /*private void SelectDirectory_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }*/


        private void studentFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForms studentForms = new StudentForms(IDcheck);
            studentForms.Show();
        }

        private void overrideQuarterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverrideQuarter overrideQuarter = new OverrideQuarter();
            overrideQuarter.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        // allow to input studentID and studentSchedule and display in console output box
        private void enterScheduleBtn_Click_1(object sender, EventArgs e)
        {
            studentSched = scheduleInputBox.Text.ToString();
            try
            {
                IDcheck.studentIDValid(studentSched.Replace("\r", ""));
                List<Course> parsedCourses = IDcheck.createStudent(studentSched.Replace("\r", ""));
                Tracker parseTracker = new Tracker(parsedCourses);
                files.getFilePath(IDcheck.StudentID);
                string result = parseTracker.matchClasses(files.getExcelFilePaths());
                studentEmailSearchBox.Text = result;
            }
            catch(Exception ex)
            {
                studentEmailSearchBox.Text = $"ERROR: \n {ex}";
            }

        }
    }
}
