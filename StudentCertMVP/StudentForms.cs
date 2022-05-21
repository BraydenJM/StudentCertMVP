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
    public partial class StudentForms : Form
    {
        FileHandler fileHandler;
        classRegex IDcheck;
        public StudentForms(FileHandler file, classRegex idcheck)
        {
            InitializeComponent();
            fileHandler = file;
            IDcheck = idcheck;
        }

        //processes student id and outputs getStudentForms() to textbox
        private void idBtn_Click_1(object sender, EventArgs e)
        {
            studentID = idInputBox.Text;
            IDcheck.studentIDValid(studentID);
            fileHandler.getFilePath(studentID);
            string[] lines = new string [(fileHandler.getStudentForms()).Count];
            (fileHandler.getStudentForms()).CopyTo(lines);
            FormNameTextBox.Lines = lines;
        }
    }
}
