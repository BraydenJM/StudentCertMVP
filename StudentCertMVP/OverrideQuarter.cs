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
        public static string OverrideValue { get; set; }
        public OverrideQuarter()
        {
            InitializeComponent();
            quarterBox.SelectedItem = "Spring";
            yearBox.SelectedItem = "2022";
        }

        private void idBtn_Click(object sender, EventArgs e)
        {
            string quarterCode = "";

            DialogResult dialogResult = MessageBox.Show($"Are you sure you would like to override the quarter to {quarterBox.SelectedItem} {yearBox.SelectedItem}?", "Override Quarter", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                switch (quarterBox.SelectedItem)
                {
                    case "Spring":
                            quarterCode = "SP";
                        break;

                    case "Summer":
                        quarterCode = "SU";
                        break;

                    case "Fall":
                        quarterCode = "FA";
                        break;

                    case "Winter":
                        quarterCode = "W";
                        break;
                }

                OverrideValue = quarterCode + " " + yearBox.SelectedItem;
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
