namespace StudentCertMVP
{
    partial class StudentForms
    {
        string studentID = "";

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //stores user input ID on btn click
        private void idBtn_Click(object sender, EventArgs e)
        {
            studentID = idInputBox.Text;
        }

        private void FormNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // taking full path of a file
            string strPath = "C:// myfiles//ref//file1.txt";

            // initialize the value of filename
            string filename = null;

            // using the method
            filename = Path.GetFileName(strPath);
            Console.WriteLine("Filename = " + filename);

            Console.ReadLine();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.FormNamesLabel = new System.Windows.Forms.Label();
            this.idBtn = new System.Windows.Forms.Button();
            this.idInputBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FormNameTextBox
            // 
            this.FormNameTextBox.Location = new System.Drawing.Point(36, 209);
            this.FormNameTextBox.Multiline = true;
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.ReadOnly = true;
            this.FormNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FormNameTextBox.Size = new System.Drawing.Size(600, 193);
            this.FormNameTextBox.TabIndex = 24;
            // 
            // FormNamesLabel
            // 
            this.FormNamesLabel.AutoSize = true;
            this.FormNamesLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormNamesLabel.Location = new System.Drawing.Point(269, 181);
            this.FormNamesLabel.Name = "FormNamesLabel";
            this.FormNamesLabel.Size = new System.Drawing.Size(124, 25);
            this.FormNamesLabel.TabIndex = 23;
            this.FormNamesLabel.Text = "Form Names";
            // 
            // idBtn
            // 
            this.idBtn.Location = new System.Drawing.Point(561, 103);
            this.idBtn.Name = "idBtn";
            this.idBtn.Size = new System.Drawing.Size(75, 33);
            this.idBtn.TabIndex = 22;
            this.idBtn.Text = "Enter";
            this.idBtn.UseVisualStyleBackColor = true;
            this.idBtn.Click += new System.EventHandler(this.idBtn_Click_1);
            // 
            // idInputBox
            // 
            this.idInputBox.Location = new System.Drawing.Point(36, 68);
            this.idInputBox.Multiline = true;
            this.idInputBox.Name = "idInputBox";
            this.idInputBox.Size = new System.Drawing.Size(600, 29);
            this.idInputBox.TabIndex = 21;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idLabel.Location = new System.Drawing.Point(245, 40);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(162, 25);
            this.idLabel.TabIndex = 20;
            this.idLabel.Text = "Student ID Input";
            // 
            // StudentForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 438);
            this.Controls.Add(this.FormNameTextBox);
            this.Controls.Add(this.FormNamesLabel);
            this.Controls.Add(this.idBtn);
            this.Controls.Add(this.idInputBox);
            this.Controls.Add(this.idLabel);
            this.Name = "StudentForms";
            this.Text = "Student Forms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox FormNameTextBox;
        private Label FormNamesLabel;
        private Button idBtn;
        private TextBox idInputBox;
        private Label idLabel;
    }
}