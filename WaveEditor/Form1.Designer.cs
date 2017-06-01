namespace WaveEditor
{
    partial class FrmEditor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditor));
            this.menuTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chartSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabWaveFunc = new System.Windows.Forms.TabControl();
            this.tabWaveEdit = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnEditPoint = new System.Windows.Forms.Button();
            this.btnDelPoint = new System.Windows.Forms.Button();
            this.btnClrPoint = new System.Windows.Forms.Button();
            this.btnGenSeries = new System.Windows.Forms.Button();
            this.tabWaveOut = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbWaveIO = new System.Windows.Forms.ComboBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.btnIOSend = new System.Windows.Forms.Button();
            this.btnWaveIOCfg = new System.Windows.Forms.Button();
            this.tblpProp = new System.Windows.Forms.TableLayoutPanel();
            this.lbSigProp = new System.Windows.Forms.Label();
            this.lbSigSampleRate = new System.Windows.Forms.Label();
            this.numSampleR = new System.Windows.Forms.NumericUpDown();
            this.lbSigSampleTime = new System.Windows.Forms.Label();
            this.txtSampleT = new System.Windows.Forms.TextBox();
            this.lbSampleB = new System.Windows.Forms.Label();
            this.numSampleB = new System.Windows.Forms.NumericUpDown();
            this.lbSampleMin = new System.Windows.Forms.Label();
            this.txtSMinVal = new System.Windows.Forms.TextBox();
            this.lbSampleMax = new System.Windows.Forms.Label();
            this.txtSMaxVal = new System.Windows.Forms.TextBox();
            this.lbSampleTime = new System.Windows.Forms.Label();
            this.lbSampleTimeVal = new System.Windows.Forms.Label();
            this.lbInteropM = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.btnSigInit = new System.Windows.Forms.Button();
            this.lbSigRealT = new System.Windows.Forms.Label();
            this.chkSigRealT = new System.Windows.Forms.CheckBox();
            this.lbDispXRange = new System.Windows.Forms.Label();
            this.lbDispYRange = new System.Windows.Forms.Label();
            this.txtXRange = new System.Windows.Forms.TextBox();
            this.txtYRange = new System.Windows.Forms.TextBox();
            this.toolChart = new System.Windows.Forms.ToolTip(this.components);
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).BeginInit();
            this.tabWaveFunc.SuspendLayout();
            this.tabWaveEdit.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabWaveOut.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tblpProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleB)).BeginInit();
            this.SuspendLayout();
            // 
            // menuTop
            // 
            this.menuTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuTop.Size = new System.Drawing.Size(1409, 30);
            this.menuTop.TabIndex = 0;
            this.menuTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSToolStripMenuItem,
            this.openOToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveSToolStripMenuItem
            // 
            this.saveSToolStripMenuItem.Name = "saveSToolStripMenuItem";
            this.saveSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveSToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.saveSToolStripMenuItem.Text = "Save (&S)";
            this.saveSToolStripMenuItem.Click += new System.EventHandler(this.saveSToolStripMenuItem_Click);
            // 
            // openOToolStripMenuItem
            // 
            this.openOToolStripMenuItem.Name = "openOToolStripMenuItem";
            this.openOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openOToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.openOToolStripMenuItem.Text = "Open (&O)";
            this.openOToolStripMenuItem.Click += new System.EventHandler(this.openOToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.generalToolStripMenuItem.Text = "General";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Enabled = false;
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            this.pluginsToolStripMenuItem.Click += new System.EventHandler(this.pluginsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tblpProp);
            this.splitContainer1.Size = new System.Drawing.Size(1409, 691);
            this.splitContainer1.SplitterDistance = 1001;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chartSignal);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabWaveFunc);
            this.splitContainer2.Size = new System.Drawing.Size(1001, 691);
            this.splitContainer2.SplitterDistance = 528;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // chartSignal
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Sample (k)";
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chartSignal.ChartAreas.Add(chartArea1);
            this.chartSignal.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartSignal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSignal.Location = new System.Drawing.Point(0, 0);
            this.chartSignal.Margin = new System.Windows.Forms.Padding(4);
            this.chartSignal.Name = "chartSignal";
            this.chartSignal.Padding = new System.Windows.Forms.Padding(0, 0, 27, 27);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.MarkerSize = 10;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series1.Name = "TSCtrl";
            series1.Points.Add(dataPoint1);
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.MarkerBorderColor = System.Drawing.Color.Blue;
            series2.MarkerBorderWidth = 3;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "TSEdit";
            this.chartSignal.Series.Add(series1);
            this.chartSignal.Series.Add(series2);
            this.chartSignal.Size = new System.Drawing.Size(1001, 528);
            this.chartSignal.TabIndex = 0;
            this.chartSignal.Text = "chart1";
            this.chartSignal.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartSignal_GetToolTipText);
            this.chartSignal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartSignal_MouseClick);
            this.chartSignal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chartSignal_MouseDoubleClick);
            // 
            // tabWaveFunc
            // 
            this.tabWaveFunc.Controls.Add(this.tabWaveEdit);
            this.tabWaveFunc.Controls.Add(this.tabWaveOut);
            this.tabWaveFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWaveFunc.Location = new System.Drawing.Point(0, 0);
            this.tabWaveFunc.Name = "tabWaveFunc";
            this.tabWaveFunc.SelectedIndex = 0;
            this.tabWaveFunc.Size = new System.Drawing.Size(1001, 158);
            this.tabWaveFunc.TabIndex = 5;
            // 
            // tabWaveEdit
            // 
            this.tabWaveEdit.Controls.Add(this.tableLayoutPanel1);
            this.tabWaveEdit.Location = new System.Drawing.Point(4, 25);
            this.tabWaveEdit.Name = "tabWaveEdit";
            this.tabWaveEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabWaveEdit.Size = new System.Drawing.Size(993, 129);
            this.tabWaveEdit.TabIndex = 0;
            this.tabWaveEdit.Text = "Wave Edit";
            this.tabWaveEdit.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddPoint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEditPoint, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDelPoint, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnClrPoint, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGenSeries, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(987, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddPoint.Enabled = false;
            this.btnAddPoint.Location = new System.Drawing.Point(11, 28);
            this.btnAddPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(175, 41);
            this.btnAddPoint.TabIndex = 0;
            this.btnAddPoint.Text = "Add Point (&A)";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnEditPoint
            // 
            this.btnEditPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditPoint.Enabled = false;
            this.btnEditPoint.Location = new System.Drawing.Point(208, 28);
            this.btnEditPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnEditPoint.Name = "btnEditPoint";
            this.btnEditPoint.Size = new System.Drawing.Size(175, 41);
            this.btnEditPoint.TabIndex = 1;
            this.btnEditPoint.Text = "Edit Point (&E)";
            this.btnEditPoint.UseVisualStyleBackColor = true;
            this.btnEditPoint.Click += new System.EventHandler(this.btnEditPoint_Click);
            // 
            // btnDelPoint
            // 
            this.btnDelPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelPoint.Enabled = false;
            this.btnDelPoint.Location = new System.Drawing.Point(405, 28);
            this.btnDelPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnDelPoint.Name = "btnDelPoint";
            this.btnDelPoint.Size = new System.Drawing.Size(175, 41);
            this.btnDelPoint.TabIndex = 2;
            this.btnDelPoint.Text = "Delete Point (&D)";
            this.btnDelPoint.UseVisualStyleBackColor = true;
            this.btnDelPoint.Click += new System.EventHandler(this.btnDelPoint_Click);
            // 
            // btnClrPoint
            // 
            this.btnClrPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClrPoint.Enabled = false;
            this.btnClrPoint.Location = new System.Drawing.Point(602, 28);
            this.btnClrPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnClrPoint.Name = "btnClrPoint";
            this.btnClrPoint.Size = new System.Drawing.Size(175, 41);
            this.btnClrPoint.TabIndex = 3;
            this.btnClrPoint.Text = "Clear All (&C)";
            this.btnClrPoint.UseVisualStyleBackColor = true;
            this.btnClrPoint.Click += new System.EventHandler(this.btnClrPoint_Click);
            // 
            // btnGenSeries
            // 
            this.btnGenSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenSeries.Enabled = false;
            this.btnGenSeries.Location = new System.Drawing.Point(799, 28);
            this.btnGenSeries.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnGenSeries.Name = "btnGenSeries";
            this.btnGenSeries.Size = new System.Drawing.Size(177, 41);
            this.btnGenSeries.TabIndex = 4;
            this.btnGenSeries.Text = "Generate (&G)";
            this.btnGenSeries.UseVisualStyleBackColor = true;
            this.btnGenSeries.Click += new System.EventHandler(this.btnGenSeries_Click);
            // 
            // tabWaveOut
            // 
            this.tabWaveOut.Controls.Add(this.tableLayoutPanel2);
            this.tabWaveOut.Location = new System.Drawing.Point(4, 25);
            this.tabWaveOut.Name = "tabWaveOut";
            this.tabWaveOut.Padding = new System.Windows.Forms.Padding(3);
            this.tabWaveOut.Size = new System.Drawing.Size(994, 129);
            this.tabWaveOut.TabIndex = 1;
            this.tabWaveOut.Text = "Wave Output";
            this.tabWaveOut.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.44482F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.44481F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.11037F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel2.Controls.Add(this.cmbWaveIO, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbPort, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnIOSend, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnWaveIOCfg, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(988, 123);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cmbWaveIO
            // 
            this.cmbWaveIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbWaveIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaveIO.FormattingEnabled = true;
            this.cmbWaveIO.Location = new System.Drawing.Point(31, 40);
            this.cmbWaveIO.Margin = new System.Windows.Forms.Padding(4);
            this.cmbWaveIO.Name = "cmbWaveIO";
            this.cmbWaveIO.Size = new System.Drawing.Size(273, 24);
            this.cmbWaveIO.TabIndex = 0;
            this.cmbWaveIO.SelectedIndexChanged += new System.EventHandler(this.cmbWaveIO_SelectedIndexChanged);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(31, 0);
            this.lbPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(273, 36);
            this.lbPort.TabIndex = 1;
            this.lbPort.Text = "Port:";
            this.lbPort.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnIOSend
            // 
            this.btnIOSend.Enabled = false;
            this.btnIOSend.Location = new System.Drawing.Point(620, 40);
            this.btnIOSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnIOSend.Name = "btnIOSend";
            this.btnIOSend.Size = new System.Drawing.Size(117, 29);
            this.btnIOSend.TabIndex = 3;
            this.btnIOSend.Text = "Send";
            this.btnIOSend.UseVisualStyleBackColor = true;
            this.btnIOSend.Click += new System.EventHandler(this.btnIOSend_Click);
            // 
            // btnWaveIOCfg
            // 
            this.btnWaveIOCfg.Enabled = false;
            this.btnWaveIOCfg.Location = new System.Drawing.Point(339, 40);
            this.btnWaveIOCfg.Margin = new System.Windows.Forms.Padding(4);
            this.btnWaveIOCfg.Name = "btnWaveIOCfg";
            this.btnWaveIOCfg.Size = new System.Drawing.Size(127, 29);
            this.btnWaveIOCfg.TabIndex = 2;
            this.btnWaveIOCfg.Text = "Advanced";
            this.btnWaveIOCfg.UseVisualStyleBackColor = true;
            this.btnWaveIOCfg.Click += new System.EventHandler(this.btnWaveIOCfg_Click);
            // 
            // tblpProp
            // 
            this.tblpProp.ColumnCount = 2;
            this.tblpProp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.03704F));
            this.tblpProp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.96296F));
            this.tblpProp.Controls.Add(this.lbSigProp, 0, 0);
            this.tblpProp.Controls.Add(this.lbSigSampleRate, 0, 2);
            this.tblpProp.Controls.Add(this.numSampleR, 1, 2);
            this.tblpProp.Controls.Add(this.lbSigSampleTime, 0, 3);
            this.tblpProp.Controls.Add(this.txtSampleT, 1, 3);
            this.tblpProp.Controls.Add(this.lbSampleB, 0, 4);
            this.tblpProp.Controls.Add(this.numSampleB, 1, 4);
            this.tblpProp.Controls.Add(this.lbSampleMin, 0, 5);
            this.tblpProp.Controls.Add(this.txtSMinVal, 1, 5);
            this.tblpProp.Controls.Add(this.lbSampleMax, 0, 6);
            this.tblpProp.Controls.Add(this.txtSMaxVal, 1, 6);
            this.tblpProp.Controls.Add(this.lbSampleTime, 0, 7);
            this.tblpProp.Controls.Add(this.lbSampleTimeVal, 1, 7);
            this.tblpProp.Controls.Add(this.lbInteropM, 0, 8);
            this.tblpProp.Controls.Add(this.cmbDataType, 1, 8);
            this.tblpProp.Controls.Add(this.btnSigInit, 0, 9);
            this.tblpProp.Controls.Add(this.lbSigRealT, 0, 10);
            this.tblpProp.Controls.Add(this.chkSigRealT, 1, 10);
            this.tblpProp.Controls.Add(this.lbDispXRange, 0, 11);
            this.tblpProp.Controls.Add(this.lbDispYRange, 0, 12);
            this.tblpProp.Controls.Add(this.txtXRange, 1, 11);
            this.tblpProp.Controls.Add(this.txtYRange, 1, 12);
            this.tblpProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpProp.Location = new System.Drawing.Point(0, 0);
            this.tblpProp.Margin = new System.Windows.Forms.Padding(4);
            this.tblpProp.Name = "tblpProp";
            this.tblpProp.RowCount = 14;
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpProp.Size = new System.Drawing.Size(403, 691);
            this.tblpProp.TabIndex = 0;
            // 
            // lbSigProp
            // 
            this.lbSigProp.AutoSize = true;
            this.tblpProp.SetColumnSpan(this.lbSigProp, 2);
            this.lbSigProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSigProp.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSigProp.Location = new System.Drawing.Point(4, 0);
            this.lbSigProp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 3);
            this.lbSigProp.Name = "lbSigProp";
            this.lbSigProp.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.lbSigProp.Size = new System.Drawing.Size(395, 57);
            this.lbSigProp.TabIndex = 0;
            this.lbSigProp.Text = "Discrete Signal Property";
            this.lbSigProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSigSampleRate
            // 
            this.lbSigSampleRate.AutoSize = true;
            this.lbSigSampleRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSigSampleRate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSigSampleRate.Location = new System.Drawing.Point(4, 95);
            this.lbSigSampleRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 3);
            this.lbSigSampleRate.Name = "lbSigSampleRate";
            this.lbSigSampleRate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.lbSigSampleRate.Size = new System.Drawing.Size(181, 32);
            this.lbSigSampleRate.TabIndex = 0;
            this.lbSigSampleRate.Text = "Sample Rate (SPS)";
            this.lbSigSampleRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSampleR
            // 
            this.numSampleR.Location = new System.Drawing.Point(193, 99);
            this.numSampleR.Margin = new System.Windows.Forms.Padding(4);
            this.numSampleR.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numSampleR.Name = "numSampleR";
            this.numSampleR.Size = new System.Drawing.Size(160, 22);
            this.numSampleR.TabIndex = 1;
            this.numSampleR.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSampleR.ValueChanged += new System.EventHandler(this.numSampleR_ValueChanged);
            // 
            // lbSigSampleTime
            // 
            this.lbSigSampleTime.AutoSize = true;
            this.lbSigSampleTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSigSampleTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSigSampleTime.Location = new System.Drawing.Point(4, 130);
            this.lbSigSampleTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSigSampleTime.Name = "lbSigSampleTime";
            this.lbSigSampleTime.Size = new System.Drawing.Size(181, 35);
            this.lbSigSampleTime.TabIndex = 2;
            this.lbSigSampleTime.Text = "Total Time (s)";
            this.lbSigSampleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSampleT
            // 
            this.txtSampleT.Location = new System.Drawing.Point(193, 134);
            this.txtSampleT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSampleT.Name = "txtSampleT";
            this.txtSampleT.Size = new System.Drawing.Size(159, 22);
            this.txtSampleT.TabIndex = 3;
            this.txtSampleT.Text = "1";
            this.txtSampleT.TextChanged += new System.EventHandler(this.numSampleR_ValueChanged);
            this.txtSampleT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleVal_KeyPress);
            // 
            // lbSampleB
            // 
            this.lbSampleB.AutoSize = true;
            this.lbSampleB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSampleB.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSampleB.Location = new System.Drawing.Point(4, 165);
            this.lbSampleB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSampleB.Name = "lbSampleB";
            this.lbSampleB.Size = new System.Drawing.Size(181, 35);
            this.lbSampleB.TabIndex = 4;
            this.lbSampleB.Text = "Sample Bits (bit)";
            this.lbSampleB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSampleB
            // 
            this.numSampleB.Location = new System.Drawing.Point(193, 169);
            this.numSampleB.Margin = new System.Windows.Forms.Padding(4);
            this.numSampleB.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numSampleB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSampleB.Name = "numSampleB";
            this.numSampleB.Size = new System.Drawing.Size(160, 22);
            this.numSampleB.TabIndex = 5;
            this.numSampleB.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // lbSampleMin
            // 
            this.lbSampleMin.AutoSize = true;
            this.lbSampleMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSampleMin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSampleMin.Location = new System.Drawing.Point(4, 200);
            this.lbSampleMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSampleMin.Name = "lbSampleMin";
            this.lbSampleMin.Size = new System.Drawing.Size(181, 35);
            this.lbSampleMin.TabIndex = 6;
            this.lbSampleMin.Text = "Mininum Value";
            this.lbSampleMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSMinVal
            // 
            this.txtSMinVal.Location = new System.Drawing.Point(193, 204);
            this.txtSMinVal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSMinVal.Name = "txtSMinVal";
            this.txtSMinVal.Size = new System.Drawing.Size(159, 22);
            this.txtSMinVal.TabIndex = 7;
            this.txtSMinVal.Text = "0";
            this.txtSMinVal.TextChanged += new System.EventHandler(this.txtDoubleVal_TextChanged);
            this.txtSMinVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleVal_KeyPress);
            // 
            // lbSampleMax
            // 
            this.lbSampleMax.AutoSize = true;
            this.lbSampleMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSampleMax.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSampleMax.Location = new System.Drawing.Point(4, 235);
            this.lbSampleMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSampleMax.Name = "lbSampleMax";
            this.lbSampleMax.Size = new System.Drawing.Size(181, 35);
            this.lbSampleMax.TabIndex = 8;
            this.lbSampleMax.Text = "Maxinum Value";
            this.lbSampleMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSMaxVal
            // 
            this.txtSMaxVal.Location = new System.Drawing.Point(193, 239);
            this.txtSMaxVal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSMaxVal.Name = "txtSMaxVal";
            this.txtSMaxVal.Size = new System.Drawing.Size(159, 22);
            this.txtSMaxVal.TabIndex = 9;
            this.txtSMaxVal.Text = "65";
            this.txtSMaxVal.TextChanged += new System.EventHandler(this.txtDoubleVal_TextChanged);
            this.txtSMaxVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleVal_KeyPress);
            // 
            // lbSampleTime
            // 
            this.lbSampleTime.AutoSize = true;
            this.lbSampleTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSampleTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSampleTime.Location = new System.Drawing.Point(4, 270);
            this.lbSampleTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSampleTime.Name = "lbSampleTime";
            this.lbSampleTime.Size = new System.Drawing.Size(181, 35);
            this.lbSampleTime.TabIndex = 10;
            this.lbSampleTime.Text = "Sample Time Ts";
            this.lbSampleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSampleTimeVal
            // 
            this.lbSampleTimeVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSampleTimeVal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSampleTimeVal.Location = new System.Drawing.Point(193, 270);
            this.lbSampleTimeVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSampleTimeVal.Name = "lbSampleTimeVal";
            this.lbSampleTimeVal.Size = new System.Drawing.Size(206, 35);
            this.lbSampleTimeVal.TabIndex = 0;
            this.lbSampleTimeVal.Text = "1E-0006";
            this.lbSampleTimeVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbInteropM
            // 
            this.lbInteropM.AutoSize = true;
            this.lbInteropM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInteropM.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInteropM.Location = new System.Drawing.Point(4, 305);
            this.lbInteropM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInteropM.Name = "lbInteropM";
            this.lbInteropM.Size = new System.Drawing.Size(181, 35);
            this.lbInteropM.TabIndex = 11;
            this.lbInteropM.Text = "Data Type";
            this.lbInteropM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbDataType
            // 
            this.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Items.AddRange(new object[] {
            "BYTE",
            "WORD",
            "DWORD",
            "QWORD",
            "Real"});
            this.cmbDataType.Location = new System.Drawing.Point(193, 309);
            this.cmbDataType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(159, 24);
            this.cmbDataType.TabIndex = 12;
            // 
            // btnSigInit
            // 
            this.tblpProp.SetColumnSpan(this.btnSigInit, 2);
            this.btnSigInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSigInit.Location = new System.Drawing.Point(3, 343);
            this.btnSigInit.Name = "btnSigInit";
            this.btnSigInit.Padding = new System.Windows.Forms.Padding(5);
            this.btnSigInit.Size = new System.Drawing.Size(397, 39);
            this.btnSigInit.TabIndex = 13;
            this.btnSigInit.Text = "Initialize";
            this.btnSigInit.UseVisualStyleBackColor = true;
            this.btnSigInit.Click += new System.EventHandler(this.btnSigInit_Click);
            // 
            // lbSigRealT
            // 
            this.lbSigRealT.AutoSize = true;
            this.lbSigRealT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSigRealT.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lbSigRealT.Location = new System.Drawing.Point(3, 385);
            this.lbSigRealT.Name = "lbSigRealT";
            this.lbSigRealT.Size = new System.Drawing.Size(183, 35);
            this.lbSigRealT.TabIndex = 14;
            this.lbSigRealT.Text = "Real Time ";
            this.lbSigRealT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSigRealT
            // 
            this.chkSigRealT.AutoSize = true;
            this.chkSigRealT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSigRealT.Enabled = false;
            this.chkSigRealT.Location = new System.Drawing.Point(192, 388);
            this.chkSigRealT.Name = "chkSigRealT";
            this.chkSigRealT.Size = new System.Drawing.Size(208, 29);
            this.chkSigRealT.TabIndex = 15;
            this.chkSigRealT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSigRealT.UseVisualStyleBackColor = true;
            this.chkSigRealT.CheckedChanged += new System.EventHandler(this.chkSigRealT_CheckedChanged);
            // 
            // lbDispXRange
            // 
            this.lbDispXRange.AutoSize = true;
            this.lbDispXRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDispXRange.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lbDispXRange.Location = new System.Drawing.Point(3, 420);
            this.lbDispXRange.Name = "lbDispXRange";
            this.lbDispXRange.Size = new System.Drawing.Size(183, 35);
            this.lbDispXRange.TabIndex = 16;
            this.lbDispXRange.Text = "X Range";
            this.lbDispXRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDispYRange
            // 
            this.lbDispYRange.AutoSize = true;
            this.lbDispYRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDispYRange.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.lbDispYRange.Location = new System.Drawing.Point(3, 455);
            this.lbDispYRange.Name = "lbDispYRange";
            this.lbDispYRange.Size = new System.Drawing.Size(183, 35);
            this.lbDispYRange.TabIndex = 17;
            this.lbDispYRange.Text = "Y Range";
            this.lbDispYRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtXRange
            // 
            this.txtXRange.Enabled = false;
            this.txtXRange.Location = new System.Drawing.Point(192, 423);
            this.txtXRange.Name = "txtXRange";
            this.txtXRange.Size = new System.Drawing.Size(160, 22);
            this.txtXRange.TabIndex = 18;
            this.txtXRange.Text = "0,1000";
            this.toolChart.SetToolTip(this.txtXRange, "Expression: Min,Max");
            this.txtXRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXRange_KeyDown);
            this.txtXRange.Leave += new System.EventHandler(this.txtXRange_TextChanged);
            // 
            // txtYRange
            // 
            this.txtYRange.Enabled = false;
            this.txtYRange.Location = new System.Drawing.Point(192, 458);
            this.txtYRange.Name = "txtYRange";
            this.txtYRange.Size = new System.Drawing.Size(161, 22);
            this.txtYRange.TabIndex = 19;
            this.txtYRange.Text = "0,65";
            this.toolChart.SetToolTip(this.txtYRange, "Expression: Min,Max");
            this.txtYRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYRange_KeyDown);
            this.txtYRange.Leave += new System.EventHandler(this.txtYRange_TextChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 721);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuTop;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEditor";
            this.Text = "Wave Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Load);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).EndInit();
            this.tabWaveFunc.ResumeLayout(false);
            this.tabWaveEdit.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabWaveOut.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tblpProp.ResumeLayout(false);
            this.tblpProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tblpProp;
        private System.Windows.Forms.Label lbSigProp;
        private System.Windows.Forms.Label lbSigSampleRate;
        private System.Windows.Forms.NumericUpDown numSampleR;
        private System.Windows.Forms.Label lbSigSampleTime;
        private System.Windows.Forms.TextBox txtSampleT;
        private System.Windows.Forms.Label lbSampleB;
        private System.Windows.Forms.NumericUpDown numSampleB;
        private System.Windows.Forms.Label lbSampleMin;
        private System.Windows.Forms.TextBox txtSMinVal;
        private System.Windows.Forms.Label lbSampleMax;
        private System.Windows.Forms.TextBox txtSMaxVal;
        private System.Windows.Forms.Label lbSampleTime;
        private System.Windows.Forms.Label lbSampleTimeVal;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSignal;
        private System.Windows.Forms.Label lbInteropM;
        private System.Windows.Forms.ToolTip toolChart;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnEditPoint;
        private System.Windows.Forms.Button btnDelPoint;
        private System.Windows.Forms.Button btnClrPoint;
        private System.Windows.Forms.Button btnGenSeries;
        private System.Windows.Forms.Button btnSigInit;
        private System.Windows.Forms.Label lbSigRealT;
        private System.Windows.Forms.CheckBox chkSigRealT;
        private System.Windows.Forms.Label lbDispXRange;
        private System.Windows.Forms.Label lbDispYRange;
        private System.Windows.Forms.TextBox txtXRange;
        private System.Windows.Forms.TextBox txtYRange;
        private System.Windows.Forms.TabControl tabWaveFunc;
        private System.Windows.Forms.TabPage tabWaveEdit;
        private System.Windows.Forms.TabPage tabWaveOut;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cmbWaveIO;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Button btnIOSend;
        private System.Windows.Forms.Button btnWaveIOCfg;
        private System.Windows.Forms.ToolStripMenuItem saveSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

