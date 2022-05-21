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

            diag.InitialDirectory = File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\config.txt");

            directoryInputBox.Text = diag.InitialDirectory;

        }


        private void browseBtn_Click(object sender, EventArgs e)
        {
                if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    directoryInputBox.Text = diag.SelectedPath;
                    diag.InitialDirectory = diag.SelectedPath;
                }
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            File.WriteAllTextAsync("config.txt", directoryInputBox.Text);
            this.Close();
        }

    }
}
