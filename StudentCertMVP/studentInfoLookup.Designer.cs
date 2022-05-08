namespace StudentCertMVP
{
    partial class studentInfoLookup
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
            this.idLabel = new System.Windows.Forms.Label();
            this.idInputBox = new System.Windows.Forms.TextBox();
            this.idBtn = new System.Windows.Forms.Button();
            this.scheduleInputLabel = new System.Windows.Forms.Label();
            this.scheduleInputBox = new System.Windows.Forms.TextBox();
            this.enterScheduleBtn = new System.Windows.Forms.Button();
            this.FormNamesLabel = new System.Windows.Forms.Label();
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.consoleOutputLabel = new System.Windows.Forms.Label();
            this.studentEmailSearchBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idLabel.Location = new System.Drawing.Point(305, 179);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(162, 25);
            this.idLabel.TabIndex = 12;
            this.idLabel.Text = "Student ID Input";
            // 
            // idInputBox
            // 
            this.idInputBox.Location = new System.Drawing.Point(22, 207);
            this.idInputBox.Multiline = true;
            this.idInputBox.Name = "idInputBox";
            this.idInputBox.Size = new System.Drawing.Size(729, 29);
            this.idInputBox.TabIndex = 13;
            this.idInputBox.TextChanged += new System.EventHandler(this.idInputBox_TextChanged);
            // 
            // idBtn
            // 
            this.idBtn.Location = new System.Drawing.Point(676, 252);
            this.idBtn.Name = "idBtn";
            this.idBtn.Size = new System.Drawing.Size(75, 33);
            this.idBtn.TabIndex = 14;
            this.idBtn.Text = "Enter";
            this.idBtn.UseVisualStyleBackColor = true;
            this.idBtn.Click += new System.EventHandler(this.idBtn_Click);
            // 
            // scheduleInputLabel
            // 
            this.scheduleInputLabel.AutoSize = true;
            this.scheduleInputLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scheduleInputLabel.Location = new System.Drawing.Point(305, 9);
            this.scheduleInputLabel.Name = "scheduleInputLabel";
            this.scheduleInputLabel.Size = new System.Drawing.Size(146, 25);
            this.scheduleInputLabel.TabIndex = 15;
            this.scheduleInputLabel.Text = "Schedule Input";
            // 
            // scheduleInputBox
            // 
            this.scheduleInputBox.AcceptsReturn = true;
            this.scheduleInputBox.AcceptsTab = true;
            this.scheduleInputBox.AllowDrop = true;
            this.scheduleInputBox.Location = new System.Drawing.Point(22, 37);
            this.scheduleInputBox.Multiline = true;
            this.scheduleInputBox.Name = "scheduleInputBox";
            this.scheduleInputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.scheduleInputBox.Size = new System.Drawing.Size(729, 106);
            this.scheduleInputBox.TabIndex = 16;
            this.scheduleInputBox.TextChanged += new System.EventHandler(this.scheduleInputBox_TextChanged);
            // 
            // enterScheduleBtn
            // 
            this.enterScheduleBtn.Location = new System.Drawing.Point(676, 149);
            this.enterScheduleBtn.Name = "enterScheduleBtn";
            this.enterScheduleBtn.Size = new System.Drawing.Size(75, 33);
            this.enterScheduleBtn.TabIndex = 17;
            this.enterScheduleBtn.Text = "Enter";
            this.enterScheduleBtn.UseVisualStyleBackColor = true;
            this.enterScheduleBtn.Click += new System.EventHandler(this.enterScheduleBtn_Click);
            // 
            // FormNamesLabel
            // 
            this.FormNamesLabel.AutoSize = true;
            this.FormNamesLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormNamesLabel.Location = new System.Drawing.Point(305, 284);
            this.FormNamesLabel.Name = "FormNamesLabel";
            this.FormNamesLabel.Size = new System.Drawing.Size(124, 25);
            this.FormNamesLabel.TabIndex = 18;
            this.FormNamesLabel.Text = "Form Names";
            // 
            // FormNameTextBox
            // 
            this.FormNameTextBox.Location = new System.Drawing.Point(22, 322);
            this.FormNameTextBox.Multiline = true;
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.ReadOnly = true;
            this.FormNameTextBox.Size = new System.Drawing.Size(729, 29);
            this.FormNameTextBox.TabIndex = 19;
            // 
            // consoleOutputLabel
            // 
            this.consoleOutputLabel.AutoSize = true;
            this.consoleOutputLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.consoleOutputLabel.Location = new System.Drawing.Point(305, 374);
            this.consoleOutputLabel.Name = "consoleOutputLabel";
            this.consoleOutputLabel.Size = new System.Drawing.Size(152, 25);
            this.consoleOutputLabel.TabIndex = 20;
            this.consoleOutputLabel.Text = "Console Output";
            // 
            // studentEmailSearchBox
            // 
            this.studentEmailSearchBox.Location = new System.Drawing.Point(22, 414);
            this.studentEmailSearchBox.Multiline = true;
            this.studentEmailSearchBox.Name = "studentEmailSearchBox";
            this.studentEmailSearchBox.ReadOnly = true;
            this.studentEmailSearchBox.Size = new System.Drawing.Size(729, 29);
            this.studentEmailSearchBox.TabIndex = 21;
            // 
            // studentInfoLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 520);
            this.Controls.Add(this.studentEmailSearchBox);
            this.Controls.Add(this.consoleOutputLabel);
            this.Controls.Add(this.FormNameTextBox);
            this.Controls.Add(this.FormNamesLabel);
            this.Controls.Add(this.enterScheduleBtn);
            this.Controls.Add(this.scheduleInputBox);
            this.Controls.Add(this.scheduleInputLabel);
            this.Controls.Add(this.idBtn);
            this.Controls.Add(this.idInputBox);
            this.Controls.Add(this.idLabel);
            this.Name = "studentInfoLookup";
            this.Text = "Student Info Lookup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label idLabel;
        private TextBox idInputBox;
        private Button idBtn;
        private Label scheduleInputLabel;
        private TextBox scheduleInputBox;
        private Button enterScheduleBtn;
        private Label FormNamesLabel;
        private TextBox FormNameTextBox;
        private Label consoleOutputLabel;
        private TextBox studentEmailSearchBox;
    }
}