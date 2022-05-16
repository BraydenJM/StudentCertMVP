namespace StudentCertMVP
{
    partial class StudentDegreeTrackingProgram
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDegreeTrackingProgram));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPTIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overrideQuarterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentEmailSearchBox = new System.Windows.Forms.TextBox();
            this.consoleOutputLabel = new System.Windows.Forms.Label();
            this.enterScheduleBtn = new System.Windows.Forms.Button();
            this.scheduleInputBox = new System.Windows.Forms.TextBox();
            this.scheduleInputLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.oPTIONSToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(753, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentFormsToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.fileToolStripMenuItem.Text = "STUDENT";
            // 
            // studentFormsToolStripMenuItem
            // 
            this.studentFormsToolStripMenuItem.Name = "studentFormsToolStripMenuItem";
            this.studentFormsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.studentFormsToolStripMenuItem.Text = "Forms";
            this.studentFormsToolStripMenuItem.Click += new System.EventHandler(this.studentFormsToolStripMenuItem_Click);
            // 
            // oPTIONSToolStripMenuItem
            // 
            this.oPTIONSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDirectoryToolStripMenuItem,
            this.overrideQuarterToolStripMenuItem});
            this.oPTIONSToolStripMenuItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.oPTIONSToolStripMenuItem.Name = "oPTIONSToolStripMenuItem";
            this.oPTIONSToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.oPTIONSToolStripMenuItem.Text = "OPTIONS";
            // 
            // selectDirectoryToolStripMenuItem
            // 
            this.selectDirectoryToolStripMenuItem.Name = "selectDirectoryToolStripMenuItem";
            this.selectDirectoryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.selectDirectoryToolStripMenuItem.Text = "Select Directory";
            this.selectDirectoryToolStripMenuItem.Click += new System.EventHandler(this.selectDirectoryToolStripMenuItem_Click);
            // 
            // overrideQuarterToolStripMenuItem
            // 
            this.overrideQuarterToolStripMenuItem.Name = "overrideQuarterToolStripMenuItem";
            this.overrideQuarterToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.overrideQuarterToolStripMenuItem.Text = "Override Quarter";
            this.overrideQuarterToolStripMenuItem.Click += new System.EventHandler(this.overrideQuarterToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.aboutToolStripMenuItem.Text = "ABOUT";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // studentEmailSearchBox
            // 
            this.studentEmailSearchBox.Location = new System.Drawing.Point(12, 291);
            this.studentEmailSearchBox.Multiline = true;
            this.studentEmailSearchBox.Name = "studentEmailSearchBox";
            this.studentEmailSearchBox.ReadOnly = true;
            this.studentEmailSearchBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.studentEmailSearchBox.Size = new System.Drawing.Size(729, 241);
            this.studentEmailSearchBox.TabIndex = 26;
            // 
            // consoleOutputLabel
            // 
            this.consoleOutputLabel.AutoSize = true;
            this.consoleOutputLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.consoleOutputLabel.Location = new System.Drawing.Point(295, 263);
            this.consoleOutputLabel.Name = "consoleOutputLabel";
            this.consoleOutputLabel.Size = new System.Drawing.Size(152, 25);
            this.consoleOutputLabel.TabIndex = 25;
            this.consoleOutputLabel.Text = "Console Output";
            // 
            // enterScheduleBtn
            // 
            this.enterScheduleBtn.Location = new System.Drawing.Point(666, 191);
            this.enterScheduleBtn.Name = "enterScheduleBtn";
            this.enterScheduleBtn.Size = new System.Drawing.Size(75, 33);
            this.enterScheduleBtn.TabIndex = 24;
            this.enterScheduleBtn.Text = "Enter";
            this.enterScheduleBtn.UseVisualStyleBackColor = true;
            // 
            // scheduleInputBox
            // 
            this.scheduleInputBox.AcceptsReturn = true;
            this.scheduleInputBox.AcceptsTab = true;
            this.scheduleInputBox.AllowDrop = true;
            this.scheduleInputBox.Location = new System.Drawing.Point(12, 79);
            this.scheduleInputBox.Multiline = true;
            this.scheduleInputBox.Name = "scheduleInputBox";
            this.scheduleInputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.scheduleInputBox.Size = new System.Drawing.Size(729, 106);
            this.scheduleInputBox.TabIndex = 23;
            // 
            // scheduleInputLabel
            // 
            this.scheduleInputLabel.AutoSize = true;
            this.scheduleInputLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scheduleInputLabel.Location = new System.Drawing.Point(295, 51);
            this.scheduleInputLabel.Name = "scheduleInputLabel";
            this.scheduleInputLabel.Size = new System.Drawing.Size(146, 25);
            this.scheduleInputLabel.TabIndex = 22;
            this.scheduleInputLabel.Text = "Schedule Input";
            // 
            // StudentDegreeTrackingProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(753, 579);
            this.Controls.Add(this.studentEmailSearchBox);
            this.Controls.Add(this.consoleOutputLabel);
            this.Controls.Add(this.enterScheduleBtn);
            this.Controls.Add(this.scheduleInputBox);
            this.Controls.Add(this.scheduleInputLabel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1000, 900);
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "StudentDegreeTrackingProgram";
            this.Text = "Student Degree Tracking Program";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem oPTIONSToolStripMenuItem;
        private ToolStripMenuItem selectDirectoryToolStripMenuItem;
        private ToolStripMenuItem overrideQuarterToolStripMenuItem;
        private ToolStripMenuItem studentFormsToolStripMenuItem;
        private TextBox studentEmailSearchBox;
        private Label consoleOutputLabel;
        private Button enterScheduleBtn;
        private TextBox scheduleInputBox;
        private Label scheduleInputLabel;
    }
}