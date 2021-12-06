namespace RecorderPlugin
{
    partial class SettingsDialog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipAddrBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipAddrLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipAddrBox
            // 
            this.ipAddrBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipAddrBox.Location = new System.Drawing.Point(80, 12);
            this.ipAddrBox.Name = "ipAddrBox";
            this.ipAddrBox.Size = new System.Drawing.Size(100, 20);
            this.ipAddrBox.TabIndex = 0;
            this.ipAddrBox.Text = "127.0.0.1";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(80, 38);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(100, 20);
            this.portBox.TabIndex = 1;
            this.portBox.Text = "4444";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(80, 64);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 2;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(22, 67);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Click += new System.EventHandler(this.passwordLabel_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(46, 41);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 4;
            this.portLabel.Text = "Port:";
            this.portLabel.Click += new System.EventHandler(this.portLabel_Click);
            // 
            // ipAddrLabel
            // 
            this.ipAddrLabel.AutoSize = true;
            this.ipAddrLabel.Location = new System.Drawing.Point(19, 15);
            this.ipAddrLabel.Name = "ipAddrLabel";
            this.ipAddrLabel.Size = new System.Drawing.Size(60, 13);
            this.ipAddrLabel.TabIndex = 5;
            this.ipAddrLabel.Text = "IP address:";
            this.ipAddrLabel.Click += new System.EventHandler(this.ipAddrLabel_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(80, 90);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 23);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(21, 90);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(53, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(195, 129);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.ipAddrLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipAddrBox);
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddrBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label ipAddrLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}
