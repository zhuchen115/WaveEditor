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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditor));
            this.menuTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.vScrChart = new System.Windows.Forms.VScrollBar();
            this.hScrChart = new System.Windows.Forms.HScrollBar();
            this.chartSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnEditPoint = new System.Windows.Forms.Button();
            this.btnDelPoint = new System.Windows.Forms.Button();
            this.btnClrPoint = new System.Windows.Forms.Button();
            this.btnGenSeries = new System.Windows.Forms.Button();
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
            this.toolChart = new System.Windows.Forms.ToolTip(this.components);
            this.btnSigInit = new System.Windows.Forms.Button();
            this.lbSigRealT = new System.Windows.Forms.Label();
            this.chkSigRealT = new System.Windows.Forms.CheckBox();
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
            this.tableLayoutPanel1.SuspendLayout();
            this.tblpProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleB)).BeginInit();
            this.SuspendLayout();
            // 
            // menuTop
            // 
            this.menuTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuTop.Size = new System.Drawing.Size(1251, 30);
            this.menuTop.TabIndex = 0;
            this.menuTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
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
            this.splitContainer1.Size = new System.Drawing.Size(1251, 710);
            this.splitContainer1.SplitterDistance = 884;
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
            this.splitContainer2.Panel1.Controls.Add(this.vScrChart);
            this.splitContainer2.Panel1.Controls.Add(this.hScrChart);
            this.splitContainer2.Panel1.Controls.Add(this.chartSignal);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(884, 710);
            this.splitContainer2.SplitterDistance = 588;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // vScrChart
            // 
            this.vScrChart.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrChart.Location = new System.Drawing.Point(867, 0);
            this.vScrChart.Name = "vScrChart";
            this.vScrChart.Size = new System.Drawing.Size(17, 571);
            this.vScrChart.TabIndex = 2;
            // 
            // hScrChart
            // 
            this.hScrChart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrChart.Location = new System.Drawing.Point(0, 571);
            this.hScrChart.Name = "hScrChart";
            this.hScrChart.Size = new System.Drawing.Size(884, 17);
            this.hScrChart.TabIndex = 1;
            // 
            // chartSignal
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSignal.ChartAreas.Add(chartArea1);
            this.chartSignal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSignal.Location = new System.Drawing.Point(0, 0);
            this.chartSignal.Margin = new System.Windows.Forms.Padding(4);
            this.chartSignal.Name = "chartSignal";
            this.chartSignal.Padding = new System.Windows.Forms.Padding(0, 0, 27, 27);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Name = "TSEdit";
            series1.Points.Add(dataPoint1);
            this.chartSignal.Series.Add(series1);
            this.chartSignal.Size = new System.Drawing.Size(884, 588);
            this.chartSignal.TabIndex = 0;
            this.chartSignal.Text = "chart1";
            this.chartSignal.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartSignal_GetToolTipText);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddPoint.Enabled = false;
            this.btnAddPoint.Location = new System.Drawing.Point(11, 39);
            this.btnAddPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(154, 38);
            this.btnAddPoint.TabIndex = 0;
            this.btnAddPoint.Text = "Add Point (&A)";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnEditPoint
            // 
            this.btnEditPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditPoint.Enabled = false;
            this.btnEditPoint.Location = new System.Drawing.Point(187, 39);
            this.btnEditPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnEditPoint.Name = "btnEditPoint";
            this.btnEditPoint.Size = new System.Drawing.Size(154, 38);
            this.btnEditPoint.TabIndex = 1;
            this.btnEditPoint.Text = "Edit Point (&E)";
            this.btnEditPoint.UseVisualStyleBackColor = true;
            // 
            // btnDelPoint
            // 
            this.btnDelPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelPoint.Enabled = false;
            this.btnDelPoint.Location = new System.Drawing.Point(363, 39);
            this.btnDelPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnDelPoint.Name = "btnDelPoint";
            this.btnDelPoint.Size = new System.Drawing.Size(154, 38);
            this.btnDelPoint.TabIndex = 2;
            this.btnDelPoint.Text = "Delete Point (&D)";
            this.btnDelPoint.UseVisualStyleBackColor = true;
            // 
            // btnClrPoint
            // 
            this.btnClrPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClrPoint.Enabled = false;
            this.btnClrPoint.Location = new System.Drawing.Point(539, 39);
            this.btnClrPoint.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnClrPoint.Name = "btnClrPoint";
            this.btnClrPoint.Size = new System.Drawing.Size(154, 38);
            this.btnClrPoint.TabIndex = 3;
            this.btnClrPoint.Text = "Clear All (&C)";
            this.btnClrPoint.UseVisualStyleBackColor = true;
            // 
            // btnGenSeries
            // 
            this.btnGenSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenSeries.Enabled = false;
            this.btnGenSeries.Location = new System.Drawing.Point(715, 39);
            this.btnGenSeries.Margin = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.btnGenSeries.Name = "btnGenSeries";
            this.btnGenSeries.Size = new System.Drawing.Size(158, 38);
            this.btnGenSeries.TabIndex = 4;
            this.btnGenSeries.Text = "Generate (&G)";
            this.btnGenSeries.UseVisualStyleBackColor = true;
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
            this.tblpProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpProp.Location = new System.Drawing.Point(0, 0);
            this.tblpProp.Margin = new System.Windows.Forms.Padding(4);
            this.tblpProp.Name = "tblpProp";
            this.tblpProp.RowCount = 12;
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
            this.tblpProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpProp.Size = new System.Drawing.Size(362, 710);
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
            this.lbSigProp.Size = new System.Drawing.Size(354, 57);
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
            this.lbSigSampleRate.Size = new System.Drawing.Size(162, 32);
            this.lbSigSampleRate.TabIndex = 0;
            this.lbSigSampleRate.Text = "Sample Rate (SPS)";
            this.lbSigSampleRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSampleR
            // 
            this.numSampleR.Location = new System.Drawing.Point(174, 99);
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
            this.lbSigSampleTime.Size = new System.Drawing.Size(162, 35);
            this.lbSigSampleTime.TabIndex = 2;
            this.lbSigSampleTime.Text = "Total Time (s)";
            this.lbSigSampleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSampleT
            // 
            this.txtSampleT.Location = new System.Drawing.Point(174, 134);
            this.txtSampleT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSampleT.Name = "txtSampleT";
            this.txtSampleT.Size = new System.Drawing.Size(159, 22);
            this.txtSampleT.TabIndex = 3;
            this.txtSampleT.Text = "1";
            this.txtSampleT.TextChanged += new System.EventHandler(this.txtDoubleVal_TextChanged);
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
            this.lbSampleB.Size = new System.Drawing.Size(162, 35);
            this.lbSampleB.TabIndex = 4;
            this.lbSampleB.Text = "Sample Bits (bit)";
            this.lbSampleB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSampleB
            // 
            this.numSampleB.Location = new System.Drawing.Point(174, 169);
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
            this.lbSampleMin.Size = new System.Drawing.Size(162, 35);
            this.lbSampleMin.TabIndex = 6;
            this.lbSampleMin.Text = "Mininum Value";
            this.lbSampleMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSMinVal
            // 
            this.txtSMinVal.Location = new System.Drawing.Point(174, 204);
            this.txtSMinVal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSMinVal.Name = "txtSMinVal";
            this.txtSMinVal.Size = new System.Drawing.Size(159, 22);
            this.txtSMinVal.TabIndex = 7;
            this.txtSMinVal.Text = "5";
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
            this.lbSampleMax.Size = new System.Drawing.Size(162, 35);
            this.lbSampleMax.TabIndex = 8;
            this.lbSampleMax.Text = "Maxinum Value";
            this.lbSampleMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSMaxVal
            // 
            this.txtSMaxVal.Location = new System.Drawing.Point(174, 239);
            this.txtSMaxVal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSMaxVal.Name = "txtSMaxVal";
            this.txtSMaxVal.Size = new System.Drawing.Size(159, 22);
            this.txtSMaxVal.TabIndex = 9;
            this.txtSMaxVal.Text = "0";
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
            this.lbSampleTime.Size = new System.Drawing.Size(162, 35);
            this.lbSampleTime.TabIndex = 10;
            this.lbSampleTime.Text = "Sample Time Ts";
            this.lbSampleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSampleTimeVal
            // 
            this.lbSampleTimeVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSampleTimeVal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSampleTimeVal.Location = new System.Drawing.Point(174, 270);
            this.lbSampleTimeVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSampleTimeVal.Name = "lbSampleTimeVal";
            this.lbSampleTimeVal.Size = new System.Drawing.Size(184, 35);
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
            this.lbInteropM.Size = new System.Drawing.Size(162, 35);
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
            this.cmbDataType.Location = new System.Drawing.Point(174, 309);
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
            this.btnSigInit.Size = new System.Drawing.Size(356, 39);
            this.btnSigInit.TabIndex = 13;
            this.btnSigInit.Text = "Initialize";
            this.btnSigInit.UseVisualStyleBackColor = true;
            this.btnSigInit.Click += new System.EventHandler(this.btnSigInit_Click);
            // 
            // lbSigRealT
            // 
            this.lbSigRealT.AutoSize = true;
            this.lbSigRealT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSigRealT.Location = new System.Drawing.Point(3, 385);
            this.lbSigRealT.Name = "lbSigRealT";
            this.lbSigRealT.Size = new System.Drawing.Size(164, 35);
            this.lbSigRealT.TabIndex = 14;
            this.lbSigRealT.Text = "Real Time ";
            this.lbSigRealT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSigRealT
            // 
            this.chkSigRealT.AutoSize = true;
            this.chkSigRealT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSigRealT.Location = new System.Drawing.Point(173, 388);
            this.chkSigRealT.Name = "chkSigRealT";
            this.chkSigRealT.Size = new System.Drawing.Size(186, 29);
            this.chkSigRealT.TabIndex = 15;
            this.chkSigRealT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSigRealT.UseVisualStyleBackColor = true;
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 740);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuTop;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEditor";
            this.Text = "WaveEditor";
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
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.VScrollBar vScrChart;
        private System.Windows.Forms.HScrollBar hScrChart;
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
    }
}

