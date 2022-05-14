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
    public partial class SelectDirectory : Form
    {
        FolderBrowserDialog diag = new FolderBrowserDialog();
        public SelectDirectory()
        {
            InitializeComponent();
            // replace C:\\ with variable grabbing filepath in config file
            diag.InitialDirectory = "C:\\";
            directoryInputBox.Text = diag.InitialDirectory;

        }


        private void browseBtn_Click(object sender, EventArgs e)
        {
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    directoryInputBox.Text = diag.SelectedPath;
                    diag.InitialDirectory = diag.SelectedPath;
                    // set config file variable here
                    // = diag.SelectedPath
                }
            
        }
    }
}
