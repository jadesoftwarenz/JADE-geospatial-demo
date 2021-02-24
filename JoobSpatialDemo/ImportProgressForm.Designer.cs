namespace JoobSpatialDemo
{
    partial class ImportProgressForm
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
            this.pgbImport = new System.Windows.Forms.ProgressBar();
            this.btnContiue = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblImportCount = new System.Windows.Forms.Label();
            this.lblImported = new System.Windows.Forms.Label();
            this.lblIgnored = new System.Windows.Forms.Label();
            this.lblIgnoredCount = new System.Windows.Forms.Label();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // pgbImport
            // 
            this.pgbImport.Location = new System.Drawing.Point(15, 29);
            this.pgbImport.Name = "pgbImport";
            this.pgbImport.Size = new System.Drawing.Size(415, 23);
            this.pgbImport.Step = 1;
            this.pgbImport.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbImport.TabIndex = 0;
            // 
            // btnContiue
            // 
            this.btnContiue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContiue.Location = new System.Drawing.Point(355, 90);
            this.btnContiue.Name = "btnContiue";
            this.btnContiue.Size = new System.Drawing.Size(75, 23);
            this.btnContiue.TabIndex = 1;
            this.btnContiue.Text = "&Continue";
            this.btnContiue.UseVisualStyleBackColor = true;
            this.btnContiue.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Importing...";
            // 
            // lblImportCount
            // 
            this.lblImportCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImportCount.Location = new System.Drawing.Point(338, 13);
            this.lblImportCount.Name = "lblImportCount";
            this.lblImportCount.Size = new System.Drawing.Size(89, 13);
            this.lblImportCount.TabIndex = 3;
            this.lblImportCount.Text = "0";
            this.lblImportCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblImported
            // 
            this.lblImported.AutoSize = true;
            this.lblImported.Location = new System.Drawing.Point(327, 13);
            this.lblImported.Name = "lblImported";
            this.lblImported.Size = new System.Drawing.Size(51, 13);
            this.lblImported.TabIndex = 4;
            this.lblImported.Text = "Imported:";
            // 
            // lblIgnored
            // 
            this.lblIgnored.AutoSize = true;
            this.lblIgnored.ForeColor = System.Drawing.Color.Red;
            this.lblIgnored.Location = new System.Drawing.Point(332, 55);
            this.lblIgnored.Name = "lblIgnored";
            this.lblIgnored.Size = new System.Drawing.Size(46, 13);
            this.lblIgnored.TabIndex = 6;
            this.lblIgnored.Text = "Ignored:";
            this.lblIgnored.Visible = false;
            // 
            // lblIgnoredCount
            // 
            this.lblIgnoredCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIgnoredCount.ForeColor = System.Drawing.Color.Red;
            this.lblIgnoredCount.Location = new System.Drawing.Point(338, 55);
            this.lblIgnoredCount.Name = "lblIgnoredCount";
            this.lblIgnoredCount.Size = new System.Drawing.Size(89, 13);
            this.lblIgnoredCount.TabIndex = 5;
            this.lblIgnoredCount.Text = "0";
            this.lblIgnoredCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblIgnoredCount.Visible = false;
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCancel.Location = new System.Drawing.Point(381, 95);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(49, 13);
            this.lnkCancel.TabIndex = 7;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel...";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CancelClicked);
            // 
            // ImportProgressForm
            // 
            this.AcceptButton = this.btnContiue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.lnkCancel;
            this.ClientSize = new System.Drawing.Size(439, 122);
            this.ControlBox = false;
            this.Controls.Add(this.lblIgnored);
            this.Controls.Add(this.btnContiue);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.lblIgnoredCount);
            this.Controls.Add(this.lblImported);
            this.Controls.Add(this.lblImportCount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pgbImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ImportProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importing Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbImport;
        private System.Windows.Forms.Button btnContiue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblImportCount;
        private System.Windows.Forms.Label lblImported;
        private System.Windows.Forms.Label lblIgnored;
        private System.Windows.Forms.Label lblIgnoredCount;
        private System.Windows.Forms.LinkLabel lnkCancel;
    }
}