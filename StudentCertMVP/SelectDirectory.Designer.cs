namespace StudentCertMVP
{
    partial class SelectDirectory
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
            this.directoryLabel = new System.Windows.Forms.Label();
            this.directoryInputBox = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.directoryLabel.Location = new System.Drawing.Point(12, 9);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(153, 25);
            this.directoryLabel.TabIndex = 21;
            this.directoryLabel.Text = "Select Directory";
            // 
            // directoryInputBox
            // 
            this.directoryInputBox.Location = new System.Drawing.Point(12, 37);
            this.directoryInputBox.Multiline = true;
            this.directoryInputBox.Name = "directoryInputBox";
            this.directoryInputBox.Size = new System.Drawing.Size(436, 29);
            this.directoryInputBox.TabIndex = 22;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(373, 72);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 33);
            this.browseBtn.TabIndex = 23;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // SelectDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 144);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.directoryInputBox);
            this.Controls.Add(this.directoryLabel);
            this.Name = "SelectDirectory";
            this.Text = "Select Directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label directoryLabel;
        private TextBox directoryInputBox;
        private Button browseBtn;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}