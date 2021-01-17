namespace JoobSpatialDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.legend = new DotSpatial.Controls.Legend();
            this.statusBar = new DotSpatial.Controls.SpatialStatusStrip();
            this.lblCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPerformance = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemLoadDefaultData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.splitPanel = new System.Windows.Forms.SplitContainer();
            this.tabControl = new DotSpatial.Controls.SpatialTabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tabLegend = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.map = new DotSpatial.Controls.Map();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolBar = new DotSpatial.Controls.SpatialToolStrip();
            this.statusBar.SuspendLayout();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
            this.splitPanel.Panel1.SuspendLayout();
            this.splitPanel.Panel2.SuspendLayout();
            this.splitPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tabLegend.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlMap.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // legend
            // 
            this.legend.BackColor = System.Drawing.Color.White;
            this.legend.ControlRectangle = new System.Drawing.Rectangle(0, 0, 214, 421);
            this.legend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 180, 428);
            this.legend.HorizontalScrollEnabled = true;
            this.legend.Indentation = 30;
            this.legend.IsInitialized = false;
            this.legend.Location = new System.Drawing.Point(3, 3);
            this.legend.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend.Name = "legend";
            this.legend.ProgressHandler = this.statusBar;
            this.legend.ResetOnResize = false;
            this.legend.SelectionFontColor = System.Drawing.Color.Black;
            this.legend.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend.Size = new System.Drawing.Size(214, 421);
            this.legend.TabIndex = 0;
            this.legend.Text = "Legend";
            this.legend.VerticalScrollEnabled = true;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCoord,
            this.lblPerformance});
            this.statusBar.Location = new System.Drawing.Point(0, 490);
            this.statusBar.Name = "statusBar";
            this.statusBar.ProgressBar = null;
            this.statusBar.ProgressLabel = this.lblCoord;
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusBar.Size = new System.Drawing.Size(764, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "Status";
            this.statusBar.Visible = false;
            // 
            // lblCoord
            // 
            this.lblCoord.AutoSize = false;
            this.lblCoord.Name = "lblCoord";
            this.lblCoord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCoord.Size = new System.Drawing.Size(250, 17);
            // 
            // lblPerformance
            // 
            this.lblPerformance.Name = "lblPerformance";
            this.lblPerformance.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.lblPerformance.Size = new System.Drawing.Size(100, 17);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemFile,
            this.mItemView});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(764, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Main Menu";
            // 
            // mItemFile
            // 
            this.mItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemLoadDefaultData,
            this.toolStripSeparator1,
            this.mItemExit});
            this.mItemFile.Name = "mItemFile";
            this.mItemFile.Size = new System.Drawing.Size(37, 20);
            this.mItemFile.Text = "&File";
            // 
            // mItemLoadDefaultData
            // 
            this.mItemLoadDefaultData.Name = "mItemLoadDefaultData";
            this.mItemLoadDefaultData.Size = new System.Drawing.Size(168, 22);
            this.mItemLoadDefaultData.Text = "&Load Default Data";
            this.mItemLoadDefaultData.Click += new System.EventHandler(this.mItemLoadDefaultData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mItemExit.Size = new System.Drawing.Size(168, 22);
            this.mItemExit.Text = "E&xit";
            this.mItemExit.Click += new System.EventHandler(this.mItemExit_Click);
            // 
            // mItemView
            // 
            this.mItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemToolBar,
            this.mItemStatusBar});
            this.mItemView.Name = "mItemView";
            this.mItemView.Size = new System.Drawing.Size(44, 20);
            this.mItemView.Text = "&View";
            // 
            // mItemToolBar
            // 
            this.mItemToolBar.Name = "mItemToolBar";
            this.mItemToolBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mItemToolBar.Size = new System.Drawing.Size(168, 22);
            this.mItemToolBar.Text = "&Tool Bar";
            this.mItemToolBar.Click += new System.EventHandler(this.mItemToolBar_Click);
            // 
            // mItemStatusBar
            // 
            this.mItemStatusBar.Name = "mItemStatusBar";
            this.mItemStatusBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mItemStatusBar.Size = new System.Drawing.Size(168, 22);
            this.mItemStatusBar.Text = "Stat&us Bar";
            this.mItemStatusBar.Click += new System.EventHandler(this.mItemStatusBar_Click);
            // 
            // splitPanel
            // 
            this.splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitPanel.IsSplitterFixed = true;
            this.splitPanel.Location = new System.Drawing.Point(0, 24);
            this.splitPanel.Name = "splitPanel";
            // 
            // splitPanel.Panel1
            // 
            this.splitPanel.Panel1.Controls.Add(this.tabControl);
            this.splitPanel.Panel1.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.splitPanel.Panel1MinSize = 228;
            // 
            // splitPanel.Panel2
            // 
            this.splitPanel.Panel2.Controls.Add(this.pnlMain);
            this.splitPanel.Size = new System.Drawing.Size(764, 466);
            this.splitPanel.SplitterDistance = 228;
            this.splitPanel.TabIndex = 1;
            this.splitPanel.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSearch);
            this.tabControl.Controls.Add(this.tabLegend);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(228, 453);
            this.tabControl.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.pnlSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(220, 427);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.AutoSize = true;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(3, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(214, 0);
            this.pnlSearch.TabIndex = 0;
            // 
            // tabLegend
            // 
            this.tabLegend.Controls.Add(this.legend);
            this.tabLegend.Location = new System.Drawing.Point(4, 22);
            this.tabLegend.Name = "tabLegend";
            this.tabLegend.Padding = new System.Windows.Forms.Padding(3);
            this.tabLegend.Size = new System.Drawing.Size(220, 427);
            this.tabLegend.TabIndex = 0;
            this.tabLegend.Text = "Legend";
            this.tabLegend.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlMap);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlMain.Size = new System.Drawing.Size(532, 466);
            this.pnlMain.TabIndex = 9;
            // 
            // pnlMap
            // 
            this.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMap.Controls.Add(this.map);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(1, 33);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(530, 432);
            this.pnlMap.TabIndex = 14;
            // 
            // map
            // 
            this.map.AllowDrop = true;
            this.map.BackColor = System.Drawing.Color.White;
            this.map.CollectAfterDraw = false;
            this.map.CollisionDetection = false;
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.ExtendBuffer = false;
            this.map.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;
            this.map.IsBusy = false;
            this.map.Legend = this.legend;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Name = "map";
            this.map.ProgressHandler = this.statusBar;
            this.map.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map.RedrawLayersWhileResizing = false;
            this.map.SelectionEnabled = false;
            this.map.Size = new System.Drawing.Size(528, 430);
            this.map.TabIndex = 0;
            this.map.GeoMouseMove += new System.EventHandler<DotSpatial.Controls.GeoMouseArgs>(this.map_GeoMouseMove);
            this.map.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.map_KeyPress);
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.toolBar);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(530, 32);
            this.pnlHeader.TabIndex = 13;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 2);
            this.lblTitle.Size = new System.Drawing.Size(62, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Map";
            // 
            // toolBar
            // 
            this.toolBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBar.ApplicationManager = null;
            this.toolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Location = new System.Drawing.Point(182, 7);
            this.toolBar.Map = this.map;
            this.toolBar.Margin = new System.Windows.Forms.Padding(5, 8, 0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(348, 25);
            this.toolBar.TabIndex = 13;
            this.toolBar.Text = "Main Tool Bar";
            this.toolBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 512);
            this.Controls.Add(this.splitPanel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(780, 550);
            this.Name = "MainForm";
            this.Text = "JOOB Spatial Feature Demo";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.splitPanel.Panel1.ResumeLayout(false);
            this.splitPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
            this.splitPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.tabLegend.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlMap.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DotSpatial.Controls.SpatialStatusStrip statusBar;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mItemFile;
        private System.Windows.Forms.ToolStripMenuItem mItemExit;
        private System.Windows.Forms.ToolStripMenuItem mItemView;
        private System.Windows.Forms.ToolStripMenuItem mItemToolBar;
        private System.Windows.Forms.ToolStripMenuItem mItemStatusBar;
        private System.Windows.Forms.SplitContainer splitPanel;
        private DotSpatial.Controls.SpatialTabControl tabControl;
        private System.Windows.Forms.TabPage tabLegend;
        private DotSpatial.Controls.Legend legend;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlMap;
        private DotSpatial.Controls.Map map;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private DotSpatial.Controls.SpatialToolStrip toolBar;
        private System.Windows.Forms.ToolStripStatusLabel lblCoord;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.ToolStripMenuItem mItemLoadDefaultData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblPerformance;


    }
}

