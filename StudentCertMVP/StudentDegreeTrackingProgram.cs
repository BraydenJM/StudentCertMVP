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
        public StudentDegreeTrackingProgram()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("c:\\");
        }
    }
}
