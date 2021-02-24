namespace JoobSpatialDemo
{
    partial class MapSearchControl
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
            this.components = new System.ComponentModel.Container();
            this.searchRegionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errPrvSearchRegion = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlSearchCommand = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbxSearchStrategy = new System.Windows.Forms.GroupBox();
            this.rdoSearchByName = new System.Windows.Forms.RadioButton();
            this.cmbSearchStrategy = new System.Windows.Forms.ComboBox();
            this.rdoSearchByGeom = new System.Windows.Forms.RadioButton();
            this.gbxRegion = new System.Windows.Forms.GroupBox();
            this.pnlCustomRegion = new System.Windows.Forms.Panel();
            this.txtRegionMaxY = new System.Windows.Forms.TextBox();
            this.lblRegionMaxY = new System.Windows.Forms.Label();
            this.txtRegionMaxX = new System.Windows.Forms.TextBox();
            this.lblRegionMaxX = new System.Windows.Forms.Label();
            this.txtRegionMinY = new System.Windows.Forms.TextBox();
            this.lblRegionMinY = new System.Windows.Forms.Label();
            this.txtRegionMinX = new System.Windows.Forms.TextBox();
            this.lblRegionMinX = new System.Windows.Forms.Label();
            this.cmbPredefinedRegions = new System.Windows.Forms.ComboBox();
            this.rdoCustomRegion = new System.Windows.Forms.RadioButton();
            this.rdoPredefinedRegion = new System.Windows.Forms.RadioButton();
            this.rdoInfinityRegion = new System.Windows.Forms.RadioButton();
            this.gbxLayers = new System.Windows.Forms.GroupBox();
            this.lnkSelectNone = new System.Windows.Forms.LinkLabel();
            this.lnkSelectAll = new System.Windows.Forms.LinkLabel();
            this.chbLayerNames = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchRegionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPrvSearchRegion)).BeginInit();
            this.pnlRoot.SuspendLayout();
            this.pnlSearchCommand.SuspendLayout();
            this.gbxSearchStrategy.SuspendLayout();
            this.gbxRegion.SuspendLayout();
            this.pnlCustomRegion.SuspendLayout();
            this.gbxLayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchRegionBindingSource
            // 
            this.searchRegionBindingSource.DataSource = typeof(JoobSpatialDemo.SearchRegion);
            // 
            // errPrvSearchRegion
            // 
            this.errPrvSearchRegion.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errPrvSearchRegion.ContainerControl = this;
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.pnlSearchCommand);
            this.pnlRoot.Controls.Add(this.gbxSearchStrategy);
            this.pnlRoot.Controls.Add(this.gbxRegion);
            this.pnlRoot.Controls.Add(this.gbxLayers);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlRoot.Size = new System.Drawing.Size(220, 502);
            this.pnlRoot.TabIndex = 1;
            // 
            // pnlSearchCommand
            // 
            this.pnlSearchCommand.AutoSize = true;
            this.pnlSearchCommand.Controls.Add(this.btnSearch);
            this.pnlSearchCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchCommand.Location = new System.Drawing.Point(3, 403);
            this.pnlSearchCommand.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlSearchCommand.Name = "pnlSearchCommand";
            this.pnlSearchCommand.Padding = new System.Windows.Forms.Padding(15, 10, 20, 10);
            this.pnlSearchCommand.Size = new System.Drawing.Size(214, 46);
            this.pnlSearchCommand.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(96, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbxSearchStrategy
            // 
            this.gbxSearchStrategy.Controls.Add(this.rdoSearchByName);
            this.gbxSearchStrategy.Controls.Add(this.cmbSearchStrategy);
            this.gbxSearchStrategy.Controls.Add(this.rdoSearchByGeom);
            this.gbxSearchStrategy.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearchStrategy.Location = new System.Drawing.Point(3, 303);
            this.gbxSearchStrategy.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbxSearchStrategy.Name = "gbxSearchStrategy";
            this.gbxSearchStrategy.Padding = new System.Windows.Forms.Padding(15, 10, 20, 10);
            this.gbxSearchStrategy.Size = new System.Drawing.Size(214, 100);
            this.gbxSearchStrategy.TabIndex = 2;
            this.gbxSearchStrategy.TabStop = false;
            this.gbxSearchStrategy.Text = "Strategy";
            // 
            // rdoSearchByName
            // 
            this.rdoSearchByName.AutoSize = true;
            this.rdoSearchByName.Location = new System.Drawing.Point(15, 73);
            this.rdoSearchByName.Name = "rdoSearchByName";
            this.rdoSearchByName.Size = new System.Drawing.Size(104, 17);
            this.rdoSearchByName.TabIndex = 2;
            this.rdoSearchByName.Text = "Search by Name";
            this.rdoSearchByName.UseVisualStyleBackColor = true;
            this.rdoSearchByName.CheckedChanged += new System.EventHandler(this.rdoSearchByName_CheckedChanged);
            // 
            // cmbSearchStrategy
            // 
            this.cmbSearchStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchStrategy.FormattingEnabled = true;
            this.cmbSearchStrategy.Items.AddRange(new object[] {
            "Contain",
            "Within",
            "Disjoint",
            "Intersect",
            "Touch",
            "Cross",
            "Overlap",
            "Equal"});
            this.cmbSearchStrategy.Location = new System.Drawing.Point(31, 46);
            this.cmbSearchStrategy.Name = "cmbSearchStrategy";
            this.cmbSearchStrategy.Size = new System.Drawing.Size(163, 21);
            this.cmbSearchStrategy.TabIndex = 1;
            // 
            // rdoSearchByGeom
            // 
            this.rdoSearchByGeom.AutoSize = true;
            this.rdoSearchByGeom.Checked = true;
            this.rdoSearchByGeom.Location = new System.Drawing.Point(15, 23);
            this.rdoSearchByGeom.Name = "rdoSearchByGeom";
            this.rdoSearchByGeom.Size = new System.Drawing.Size(121, 17);
            this.rdoSearchByGeom.TabIndex = 0;
            this.rdoSearchByGeom.TabStop = true;
            this.rdoSearchByGeom.Text = "Search by Geometry";
            this.rdoSearchByGeom.UseVisualStyleBackColor = true;
            this.rdoSearchByGeom.CheckedChanged += new System.EventHandler(this.rdoSearchByGeom_CheckedChanged);
            // 
            // gbxRegion
            // 
            this.gbxRegion.AutoSize = true;
            this.gbxRegion.Controls.Add(this.pnlCustomRegion);
            this.gbxRegion.Controls.Add(this.cmbPredefinedRegions);
            this.gbxRegion.Controls.Add(this.rdoCustomRegion);
            this.gbxRegion.Controls.Add(this.rdoPredefinedRegion);
            this.gbxRegion.Controls.Add(this.rdoInfinityRegion);
            this.gbxRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxRegion.Location = new System.Drawing.Point(3, 119);
            this.gbxRegion.Name = "gbxRegion";
            this.gbxRegion.Padding = new System.Windows.Forms.Padding(15, 10, 20, 5);
            this.gbxRegion.Size = new System.Drawing.Size(214, 184);
            this.gbxRegion.TabIndex = 1;
            this.gbxRegion.TabStop = false;
            this.gbxRegion.Text = "Region";
            // 
            // pnlCustomRegion
            // 
            this.pnlCustomRegion.AutoSize = true;
            this.pnlCustomRegion.Controls.Add(this.txtRegionMaxY);
            this.pnlCustomRegion.Controls.Add(this.lblRegionMaxY);
            this.pnlCustomRegion.Controls.Add(this.txtRegionMaxX);
            this.pnlCustomRegion.Controls.Add(this.lblRegionMaxX);
            this.pnlCustomRegion.Controls.Add(this.txtRegionMinY);
            this.pnlCustomRegion.Controls.Add(this.lblRegionMinY);
            this.pnlCustomRegion.Controls.Add(this.txtRegionMinX);
            this.pnlCustomRegion.Controls.Add(this.lblRegionMinX);
            this.pnlCustomRegion.Location = new System.Drawing.Point(15, 83);
            this.pnlCustomRegion.Name = "pnlCustomRegion";
            this.pnlCustomRegion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.pnlCustomRegion.Size = new System.Drawing.Size(199, 80);
            this.pnlCustomRegion.TabIndex = 4;
            this.pnlCustomRegion.Visible = false;
            // 
            // txtRegionMaxY
            // 
            this.txtRegionMaxY.Location = new System.Drawing.Point(63, 57);
            this.txtRegionMaxY.MaxLength = 50;
            this.txtRegionMaxY.Name = "txtRegionMaxY";
            this.txtRegionMaxY.Size = new System.Drawing.Size(116, 20);
            this.txtRegionMaxY.TabIndex = 7;
            this.txtRegionMaxY.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoubleValue);
            // 
            // lblRegionMaxY
            // 
            this.lblRegionMaxY.AutoSize = true;
            this.lblRegionMaxY.Location = new System.Drawing.Point(19, 60);
            this.lblRegionMaxY.Name = "lblRegionMaxY";
            this.lblRegionMaxY.Size = new System.Drawing.Size(37, 13);
            this.lblRegionMaxY.TabIndex = 6;
            this.lblRegionMaxY.Text = "Max Y";
            // 
            // txtRegionMaxX
            // 
            this.txtRegionMaxX.Location = new System.Drawing.Point(63, 39);
            this.txtRegionMaxX.MaxLength = 50;
            this.txtRegionMaxX.Name = "txtRegionMaxX";
            this.txtRegionMaxX.Size = new System.Drawing.Size(116, 20);
            this.txtRegionMaxX.TabIndex = 5;
            this.txtRegionMaxX.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoubleValue);
            // 
            // lblRegionMaxX
            // 
            this.lblRegionMaxX.AutoSize = true;
            this.lblRegionMaxX.Location = new System.Drawing.Point(19, 42);
            this.lblRegionMaxX.Name = "lblRegionMaxX";
            this.lblRegionMaxX.Size = new System.Drawing.Size(37, 13);
            this.lblRegionMaxX.TabIndex = 4;
            this.lblRegionMaxX.Text = "Max X";
            // 
            // txtRegionMinY
            // 
            this.txtRegionMinY.Location = new System.Drawing.Point(63, 21);
            this.txtRegionMinY.MaxLength = 50;
            this.txtRegionMinY.Name = "txtRegionMinY";
            this.txtRegionMinY.Size = new System.Drawing.Size(116, 20);
            this.txtRegionMinY.TabIndex = 3;
            this.txtRegionMinY.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoubleValue);
            // 
            // lblRegionMinY
            // 
            this.lblRegionMinY.AutoSize = true;
            this.lblRegionMinY.Location = new System.Drawing.Point(22, 24);
            this.lblRegionMinY.Name = "lblRegionMinY";
            this.lblRegionMinY.Size = new System.Drawing.Size(34, 13);
            this.lblRegionMinY.TabIndex = 2;
            this.lblRegionMinY.Text = "Min Y";
            // 
            // txtRegionMinX
            // 
            this.txtRegionMinX.Location = new System.Drawing.Point(63, 3);
            this.txtRegionMinX.MaxLength = 50;
            this.txtRegionMinX.Name = "txtRegionMinX";
            this.txtRegionMinX.Size = new System.Drawing.Size(116, 20);
            this.txtRegionMinX.TabIndex = 1;
            this.txtRegionMinX.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoubleValue);
            // 
            // lblRegionMinX
            // 
            this.lblRegionMinX.AutoSize = true;
            this.lblRegionMinX.Location = new System.Drawing.Point(22, 6);
            this.lblRegionMinX.Name = "lblRegionMinX";
            this.lblRegionMinX.Size = new System.Drawing.Size(34, 13);
            this.lblRegionMinX.TabIndex = 0;
            this.lblRegionMinX.Text = "Min X";
            // 
            // cmbPredefinedRegions
            // 
            this.cmbPredefinedRegions.DataSource = this.searchRegionBindingSource;
            this.cmbPredefinedRegions.DisplayMember = "Name";
            this.cmbPredefinedRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPredefinedRegions.Enabled = false;
            this.cmbPredefinedRegions.FormattingEnabled = true;
            this.cmbPredefinedRegions.Location = new System.Drawing.Point(96, 42);
            this.cmbPredefinedRegions.Name = "cmbPredefinedRegions";
            this.cmbPredefinedRegions.Size = new System.Drawing.Size(98, 21);
            this.cmbPredefinedRegions.TabIndex = 2;
            this.cmbPredefinedRegions.ValueMember = "Envelope";
            // 
            // rdoCustomRegion
            // 
            this.rdoCustomRegion.AutoSize = true;
            this.rdoCustomRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdoCustomRegion.Location = new System.Drawing.Point(15, 63);
            this.rdoCustomRegion.Name = "rdoCustomRegion";
            this.rdoCustomRegion.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.rdoCustomRegion.Size = new System.Drawing.Size(179, 20);
            this.rdoCustomRegion.TabIndex = 3;
            this.rdoCustomRegion.Text = "Custom...";
            this.rdoCustomRegion.UseVisualStyleBackColor = true;
            this.rdoCustomRegion.CheckedChanged += new System.EventHandler(this.rdoCustomRegion_CheckedChanged);
            // 
            // rdoPredefinedRegion
            // 
            this.rdoPredefinedRegion.AutoSize = true;
            this.rdoPredefinedRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdoPredefinedRegion.Location = new System.Drawing.Point(15, 43);
            this.rdoPredefinedRegion.Name = "rdoPredefinedRegion";
            this.rdoPredefinedRegion.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.rdoPredefinedRegion.Size = new System.Drawing.Size(179, 20);
            this.rdoPredefinedRegion.TabIndex = 1;
            this.rdoPredefinedRegion.Text = "Predefined";
            this.rdoPredefinedRegion.UseVisualStyleBackColor = true;
            this.rdoPredefinedRegion.CheckedChanged += new System.EventHandler(this.rdoPredefinedRegion_CheckedChanged);
            // 
            // rdoInfinityRegion
            // 
            this.rdoInfinityRegion.AutoSize = true;
            this.rdoInfinityRegion.Checked = true;
            this.rdoInfinityRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdoInfinityRegion.Location = new System.Drawing.Point(15, 23);
            this.rdoInfinityRegion.Name = "rdoInfinityRegion";
            this.rdoInfinityRegion.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.rdoInfinityRegion.Size = new System.Drawing.Size(179, 20);
            this.rdoInfinityRegion.TabIndex = 0;
            this.rdoInfinityRegion.TabStop = true;
            this.rdoInfinityRegion.Text = "Unbounded";
            this.rdoInfinityRegion.UseVisualStyleBackColor = true;
            // 
            // gbxLayers
            // 
            this.gbxLayers.AutoSize = true;
            this.gbxLayers.Controls.Add(this.lnkSelectNone);
            this.gbxLayers.Controls.Add(this.lnkSelectAll);
            this.gbxLayers.Controls.Add(this.chbLayerNames);
            this.gbxLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxLayers.Location = new System.Drawing.Point(3, 5);
            this.gbxLayers.Name = "gbxLayers";
            this.gbxLayers.Padding = new System.Windows.Forms.Padding(15, 10, 20, 0);
            this.gbxLayers.Size = new System.Drawing.Size(214, 114);
            this.gbxLayers.TabIndex = 0;
            this.gbxLayers.TabStop = false;
            this.gbxLayers.Text = "Layers";
            // 
            // lnkSelectNone
            // 
            this.lnkSelectNone.AutoSize = true;
            this.lnkSelectNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectNone.Location = new System.Drawing.Point(75, 88);
            this.lnkSelectNone.Name = "lnkSelectNone";
            this.lnkSelectNone.Size = new System.Drawing.Size(66, 13);
            this.lnkSelectNone.TabIndex = 2;
            this.lnkSelectNone.TabStop = true;
            this.lnkSelectNone.Text = "Select None";
            this.lnkSelectNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectNone_LinkClicked);
            // 
            // lnkSelectAll
            // 
            this.lnkSelectAll.AutoSize = true;
            this.lnkSelectAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSelectAll.Location = new System.Drawing.Point(18, 88);
            this.lnkSelectAll.Name = "lnkSelectAll";
            this.lnkSelectAll.Size = new System.Drawing.Size(51, 13);
            this.lnkSelectAll.TabIndex = 1;
            this.lnkSelectAll.TabStop = true;
            this.lnkSelectAll.Text = "Select All";
            this.lnkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectAll_LinkClicked);
            // 
            // chbLayerNames
            // 
            this.chbLayerNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chbLayerNames.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbLayerNames.FormattingEnabled = true;
            this.chbLayerNames.Items.AddRange(new object[] {
            "Layer 1",
            "Layer 2",
            "Layer 3",
            "Layer 4"});
            this.chbLayerNames.Location = new System.Drawing.Point(15, 23);
            this.chbLayerNames.Name = "chbLayerNames";
            this.chbLayerNames.Size = new System.Drawing.Size(179, 62);
            this.chbLayerNames.TabIndex = 0;
            // 
            // MapSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRoot);
            this.Name = "MapSearchControl";
            this.Size = new System.Drawing.Size(220, 502);
            ((System.ComponentModel.ISupportInitialize)(this.searchRegionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPrvSearchRegion)).EndInit();
            this.pnlRoot.ResumeLayout(false);
            this.pnlRoot.PerformLayout();
            this.pnlSearchCommand.ResumeLayout(false);
            this.gbxSearchStrategy.ResumeLayout(false);
            this.gbxSearchStrategy.PerformLayout();
            this.gbxRegion.ResumeLayout(false);
            this.gbxRegion.PerformLayout();
            this.pnlCustomRegion.ResumeLayout(false);
            this.pnlCustomRegion.PerformLayout();
            this.gbxLayers.ResumeLayout(false);
            this.gbxLayers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource searchRegionBindingSource;
        private System.Windows.Forms.ErrorProvider errPrvSearchRegion;
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.GroupBox gbxSearchStrategy;
        private System.Windows.Forms.ComboBox cmbSearchStrategy;
        private System.Windows.Forms.GroupBox gbxRegion;
        private System.Windows.Forms.Panel pnlCustomRegion;
        private System.Windows.Forms.TextBox txtRegionMaxY;
        private System.Windows.Forms.Label lblRegionMaxY;
        private System.Windows.Forms.TextBox txtRegionMaxX;
        private System.Windows.Forms.Label lblRegionMaxX;
        private System.Windows.Forms.TextBox txtRegionMinY;
        private System.Windows.Forms.Label lblRegionMinY;
        private System.Windows.Forms.TextBox txtRegionMinX;
        private System.Windows.Forms.Label lblRegionMinX;
        private System.Windows.Forms.ComboBox cmbPredefinedRegions;
        private System.Windows.Forms.RadioButton rdoCustomRegion;
        private System.Windows.Forms.RadioButton rdoPredefinedRegion;
        private System.Windows.Forms.RadioButton rdoInfinityRegion;
        private System.Windows.Forms.GroupBox gbxLayers;
        private System.Windows.Forms.LinkLabel lnkSelectNone;
        private System.Windows.Forms.LinkLabel lnkSelectAll;
        private System.Windows.Forms.CheckedListBox chbLayerNames;
        private System.Windows.Forms.Panel pnlSearchCommand;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoSearchByName;
        private System.Windows.Forms.RadioButton rdoSearchByGeom;
    }
}
