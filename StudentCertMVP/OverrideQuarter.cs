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
    public partial class OverrideQuarter : Form
    {
        public OverrideQuarter()
        {
            InitializeComponent();
            quarterBox.SelectedItem = "Spring";
            yearBox.SelectedItem = "2022";
        }

        private void idBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
