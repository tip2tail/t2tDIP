namespace t2tDIP
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUpdate = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.btnNewAuth = new System.Windows.Forms.Button();
            this.btnUpdateNow = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.txtAuthCode = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAuthCode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtURL, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbUpdate, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 129);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auth Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Update Service URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Update Frequency:";
            // 
            // cmbUpdate
            // 
            this.cmbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdate.FormattingEnabled = true;
            this.cmbUpdate.Items.AddRange(new object[] {
            "10 minutes",
            "30 minutes",
            "60 minutes (1 hour)",
            "120 minutes (2 hours)",
            "12 hours",
            "24 hours"});
            this.cmbUpdate.Location = new System.Drawing.Point(3, 94);
            this.cmbUpdate.Name = "cmbUpdate";
            this.cmbUpdate.Size = new System.Drawing.Size(316, 21);
            this.cmbUpdate.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::t2tDIP.Properties.Resources.favicon;
            this.pictureBox1.Location = new System.Drawing.Point(340, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(358, 147);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(75, 23);
            this.btnLogs.TabIndex = 3;
            this.btnLogs.Text = "Logs...";
            this.btnLogs.UseVisualStyleBackColor = true;
            // 
            // btnGitHub
            // 
            this.btnGitHub.Location = new System.Drawing.Point(340, 104);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(99, 23);
            this.btnGitHub.TabIndex = 4;
            this.btnGitHub.Text = "About...";
            this.btnGitHub.UseVisualStyleBackColor = true;
            this.btnGitHub.Click += new System.EventHandler(this.BtnGitHub_Click);
            // 
            // btnNewAuth
            // 
            this.btnNewAuth.Location = new System.Drawing.Point(247, 147);
            this.btnNewAuth.Name = "btnNewAuth";
            this.btnNewAuth.Size = new System.Drawing.Size(105, 23);
            this.btnNewAuth.TabIndex = 5;
            this.btnNewAuth.Text = "New Auth Code";
            this.btnNewAuth.UseVisualStyleBackColor = true;
            this.btnNewAuth.Click += new System.EventHandler(this.BtnNewAuth_Click);
            // 
            // btnUpdateNow
            // 
            this.btnUpdateNow.Location = new System.Drawing.Point(136, 147);
            this.btnUpdateNow.Name = "btnUpdateNow";
            this.btnUpdateNow.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateNow.TabIndex = 6;
            this.btnUpdateNow.Text = "Update Now";
            this.btnUpdateNow.UseVisualStyleBackColor = true;
            this.btnUpdateNow.Click += new System.EventHandler(this.BtnUpdateNow_Click);
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::t2tDIP.Properties.Settings.Default, "AuthCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAuthCode.Location = new System.Drawing.Point(3, 16);
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.ReadOnly = true;
            this.txtAuthCode.Size = new System.Drawing.Size(316, 20);
            this.txtAuthCode.TabIndex = 1;
            this.txtAuthCode.Text = global::t2tDIP.Properties.Settings.Default.AuthCode;
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::t2tDIP.Properties.Settings.Default, "UpdateServiceURL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtURL.Location = new System.Drawing.Point(3, 55);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(316, 20);
            this.txtURL.TabIndex = 3;
            this.txtURL.Text = global::t2tDIP.Properties.Settings.Default.UpdateServiceURL;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 175);
            this.Controls.Add(this.btnUpdateNow);
            this.Controls.Add(this.btnNewAuth);
            this.Controls.Add(this.btnGitHub);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "t2tDIP";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnGitHub;
        private System.Windows.Forms.Button btnNewAuth;
        private System.Windows.Forms.Button btnUpdateNow;
        private System.Windows.Forms.Timer timerUpdate;
    }
}

