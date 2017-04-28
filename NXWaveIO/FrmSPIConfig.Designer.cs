namespace NXWaveIO
{
    partial class FrmSPIConfig
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tabGen = new System.Windows.Forms.TabPage();
            this.tblGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.lbGeDev = new System.Windows.Forms.Label();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.btnDevRefresh = new System.Windows.Forms.Button();
            this.lbGeOp = new System.Windows.Forms.Label();
            this.lbGeOpened = new System.Windows.Forms.Label();
            this.lbGeIDII = new System.Windows.Forms.Label();
            this.lbGeID = new System.Windows.Forms.Label();
            this.lbGeLocIDII = new System.Windows.Forms.Label();
            this.lbGeLocID = new System.Windows.Forms.Label();
            this.lbGeSNII = new System.Windows.Forms.Label();
            this.lbGeSN = new System.Windows.Forms.Label();
            this.lbGeDescII = new System.Windows.Forms.Label();
            this.lbGeDesc = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tabSPICfg = new System.Windows.Forms.TabPage();
            this.tblSPICfg = new System.Windows.Forms.TableLayoutPanel();
            this.lbSPClkDiv = new System.Windows.Forms.Label();
            this.numClkDiv = new System.Windows.Forms.NumericUpDown();
            this.lbSPIFreqll = new System.Windows.Forms.Label();
            this.lbSPIFreq = new System.Windows.Forms.Label();
            this.btnSPIInit = new System.Windows.Forms.Button();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.tblDevCmd = new System.Windows.Forms.TableLayoutPanel();
            this.lbDevTitle = new System.Windows.Forms.Label();
            this.btnDevReset = new System.Windows.Forms.Button();
            this.chkDevClosedLp = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tabGen.SuspendLayout();
            this.tblGeneral.SuspendLayout();
            this.tabSPICfg.SuspendLayout();
            this.tblSPICfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClkDiv)).BeginInit();
            this.tabOutput.SuspendLayout();
            this.tblDevCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(766, 450);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.tabGen);
            this.tabConfig.Controls.Add(this.tabSPICfg);
            this.tabConfig.Controls.Add(this.tabOutput);
            this.tabConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfig.Location = new System.Drawing.Point(0, 0);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(766, 405);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.Visible = false;
            // 
            // tabGen
            // 
            this.tabGen.Controls.Add(this.tblGeneral);
            this.tabGen.Location = new System.Drawing.Point(4, 22);
            this.tabGen.Name = "tabGen";
            this.tabGen.Padding = new System.Windows.Forms.Padding(3);
            this.tabGen.Size = new System.Drawing.Size(758, 379);
            this.tabGen.TabIndex = 0;
            this.tabGen.Text = "General";
            this.tabGen.UseVisualStyleBackColor = true;
            // 
            // tblGeneral
            // 
            this.tblGeneral.ColumnCount = 5;
            this.tblGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tblGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tblGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblGeneral.Controls.Add(this.lbGeDev, 1, 1);
            this.tblGeneral.Controls.Add(this.cmbDevices, 2, 1);
            this.tblGeneral.Controls.Add(this.btnDevRefresh, 3, 1);
            this.tblGeneral.Controls.Add(this.lbGeOp, 1, 2);
            this.tblGeneral.Controls.Add(this.lbGeOpened, 2, 2);
            this.tblGeneral.Controls.Add(this.lbGeIDII, 1, 3);
            this.tblGeneral.Controls.Add(this.lbGeID, 2, 3);
            this.tblGeneral.Controls.Add(this.lbGeLocIDII, 1, 4);
            this.tblGeneral.Controls.Add(this.lbGeLocID, 2, 4);
            this.tblGeneral.Controls.Add(this.lbGeSNII, 1, 5);
            this.tblGeneral.Controls.Add(this.lbGeSN, 2, 5);
            this.tblGeneral.Controls.Add(this.lbGeDescII, 1, 6);
            this.tblGeneral.Controls.Add(this.lbGeDesc, 2, 6);
            this.tblGeneral.Controls.Add(this.btnConnect, 3, 6);
            this.tblGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGeneral.Location = new System.Drawing.Point(3, 3);
            this.tblGeneral.Name = "tblGeneral";
            this.tblGeneral.RowCount = 8;
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblGeneral.Size = new System.Drawing.Size(752, 373);
            this.tblGeneral.TabIndex = 0;
            // 
            // lbGeDev
            // 
            this.lbGeDev.AutoSize = true;
            this.lbGeDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeDev.Location = new System.Drawing.Point(143, 20);
            this.lbGeDev.Name = "lbGeDev";
            this.lbGeDev.Size = new System.Drawing.Size(94, 55);
            this.lbGeDev.TabIndex = 0;
            this.lbGeDev.Text = "Devices:";
            // 
            // cmbDevices
            // 
            this.cmbDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(243, 23);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(224, 20);
            this.cmbDevices.TabIndex = 1;
            // 
            // btnDevRefresh
            // 
            this.btnDevRefresh.Location = new System.Drawing.Point(473, 23);
            this.btnDevRefresh.Name = "btnDevRefresh";
            this.btnDevRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnDevRefresh.TabIndex = 2;
            this.btnDevRefresh.Text = "Refresh";
            this.btnDevRefresh.UseVisualStyleBackColor = true;
            this.btnDevRefresh.Click += new System.EventHandler(this.btnDevRefresh_Click);
            // 
            // lbGeOp
            // 
            this.lbGeOp.AutoSize = true;
            this.lbGeOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeOp.Location = new System.Drawing.Point(143, 75);
            this.lbGeOp.Name = "lbGeOp";
            this.lbGeOp.Size = new System.Drawing.Size(94, 55);
            this.lbGeOp.TabIndex = 3;
            this.lbGeOp.Text = "Opened:";
            this.lbGeOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeOpened
            // 
            this.lbGeOpened.AutoSize = true;
            this.lbGeOpened.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeOpened.Location = new System.Drawing.Point(243, 75);
            this.lbGeOpened.Name = "lbGeOpened";
            this.lbGeOpened.Size = new System.Drawing.Size(224, 55);
            this.lbGeOpened.TabIndex = 4;
            this.lbGeOpened.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeIDII
            // 
            this.lbGeIDII.AutoSize = true;
            this.lbGeIDII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeIDII.Location = new System.Drawing.Point(143, 130);
            this.lbGeIDII.Name = "lbGeIDII";
            this.lbGeIDII.Size = new System.Drawing.Size(94, 55);
            this.lbGeIDII.TabIndex = 5;
            this.lbGeIDII.Text = "ID:";
            this.lbGeIDII.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeID
            // 
            this.lbGeID.AutoSize = true;
            this.lbGeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeID.Location = new System.Drawing.Point(243, 130);
            this.lbGeID.Name = "lbGeID";
            this.lbGeID.Size = new System.Drawing.Size(224, 55);
            this.lbGeID.TabIndex = 6;
            this.lbGeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeLocIDII
            // 
            this.lbGeLocIDII.AutoSize = true;
            this.lbGeLocIDII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeLocIDII.Location = new System.Drawing.Point(143, 185);
            this.lbGeLocIDII.Name = "lbGeLocIDII";
            this.lbGeLocIDII.Size = new System.Drawing.Size(94, 55);
            this.lbGeLocIDII.TabIndex = 7;
            this.lbGeLocIDII.Text = "LocID:";
            this.lbGeLocIDII.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeLocID
            // 
            this.lbGeLocID.AutoSize = true;
            this.lbGeLocID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeLocID.Location = new System.Drawing.Point(243, 185);
            this.lbGeLocID.Name = "lbGeLocID";
            this.lbGeLocID.Size = new System.Drawing.Size(224, 55);
            this.lbGeLocID.TabIndex = 8;
            this.lbGeLocID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeSNII
            // 
            this.lbGeSNII.AutoSize = true;
            this.lbGeSNII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeSNII.Location = new System.Drawing.Point(143, 240);
            this.lbGeSNII.Name = "lbGeSNII";
            this.lbGeSNII.Size = new System.Drawing.Size(94, 55);
            this.lbGeSNII.TabIndex = 9;
            this.lbGeSNII.Text = "S/N:";
            this.lbGeSNII.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeSN
            // 
            this.lbGeSN.AutoSize = true;
            this.lbGeSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeSN.Location = new System.Drawing.Point(243, 240);
            this.lbGeSN.Name = "lbGeSN";
            this.lbGeSN.Size = new System.Drawing.Size(224, 55);
            this.lbGeSN.TabIndex = 10;
            this.lbGeSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeDescII
            // 
            this.lbGeDescII.AutoSize = true;
            this.lbGeDescII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeDescII.Location = new System.Drawing.Point(143, 295);
            this.lbGeDescII.Name = "lbGeDescII";
            this.lbGeDescII.Size = new System.Drawing.Size(94, 55);
            this.lbGeDescII.TabIndex = 11;
            this.lbGeDescII.Text = "Description:";
            this.lbGeDescII.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGeDesc
            // 
            this.lbGeDesc.AutoSize = true;
            this.lbGeDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGeDesc.Location = new System.Drawing.Point(243, 295);
            this.lbGeDesc.Name = "lbGeDesc";
            this.lbGeDesc.Size = new System.Drawing.Size(224, 55);
            this.lbGeDesc.TabIndex = 12;
            this.lbGeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(518, 312);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 35);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // tabSPICfg
            // 
            this.tabSPICfg.Controls.Add(this.tblSPICfg);
            this.tabSPICfg.Location = new System.Drawing.Point(4, 22);
            this.tabSPICfg.Name = "tabSPICfg";
            this.tabSPICfg.Padding = new System.Windows.Forms.Padding(3);
            this.tabSPICfg.Size = new System.Drawing.Size(758, 379);
            this.tabSPICfg.TabIndex = 1;
            this.tabSPICfg.Text = "SPI";
            this.tabSPICfg.UseVisualStyleBackColor = true;
            // 
            // tblSPICfg
            // 
            this.tblSPICfg.ColumnCount = 5;
            this.tblSPICfg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSPICfg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tblSPICfg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblSPICfg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblSPICfg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblSPICfg.Controls.Add(this.lbSPClkDiv, 1, 1);
            this.tblSPICfg.Controls.Add(this.numClkDiv, 2, 1);
            this.tblSPICfg.Controls.Add(this.lbSPIFreqll, 1, 2);
            this.tblSPICfg.Controls.Add(this.lbSPIFreq, 2, 2);
            this.tblSPICfg.Controls.Add(this.btnSPIInit, 3, 3);
            this.tblSPICfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSPICfg.Location = new System.Drawing.Point(3, 3);
            this.tblSPICfg.Margin = new System.Windows.Forms.Padding(2);
            this.tblSPICfg.Name = "tblSPICfg";
            this.tblSPICfg.RowCount = 5;
            this.tblSPICfg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblSPICfg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSPICfg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSPICfg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblSPICfg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblSPICfg.Size = new System.Drawing.Size(752, 373);
            this.tblSPICfg.TabIndex = 0;
            // 
            // lbSPClkDiv
            // 
            this.lbSPClkDiv.AutoSize = true;
            this.lbSPClkDiv.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSPClkDiv.Location = new System.Drawing.Point(169, 15);
            this.lbSPClkDiv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSPClkDiv.Name = "lbSPClkDiv";
            this.lbSPClkDiv.Size = new System.Drawing.Size(94, 24);
            this.lbSPClkDiv.TabIndex = 0;
            this.lbSPClkDiv.Text = "Clock Divisor :";
            // 
            // numClkDiv
            // 
            this.numClkDiv.Dock = System.Windows.Forms.DockStyle.Top;
            this.numClkDiv.Location = new System.Drawing.Point(267, 17);
            this.numClkDiv.Margin = new System.Windows.Forms.Padding(2);
            this.numClkDiv.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numClkDiv.Name = "numClkDiv";
            this.numClkDiv.Size = new System.Drawing.Size(146, 21);
            this.numClkDiv.TabIndex = 1;
            this.numClkDiv.ValueChanged += new System.EventHandler(this.numClkDiv_ValueChanged);
            // 
            // lbSPIFreqll
            // 
            this.lbSPIFreqll.AutoSize = true;
            this.lbSPIFreqll.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSPIFreqll.Location = new System.Drawing.Point(169, 129);
            this.lbSPIFreqll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSPIFreqll.Name = "lbSPIFreqll";
            this.lbSPIFreqll.Size = new System.Drawing.Size(94, 12);
            this.lbSPIFreqll.TabIndex = 2;
            this.lbSPIFreqll.Text = "SPI Clock:";
            // 
            // lbSPIFreq
            // 
            this.lbSPIFreq.AutoSize = true;
            this.lbSPIFreq.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSPIFreq.Location = new System.Drawing.Point(267, 129);
            this.lbSPIFreq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSPIFreq.Name = "lbSPIFreq";
            this.lbSPIFreq.Size = new System.Drawing.Size(146, 12);
            this.lbSPIFreq.TabIndex = 3;
            this.lbSPIFreq.Text = "30MHz";
            // 
            // btnSPIInit
            // 
            this.btnSPIInit.Location = new System.Drawing.Point(417, 245);
            this.btnSPIInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSPIInit.Name = "btnSPIInit";
            this.btnSPIInit.Size = new System.Drawing.Size(80, 40);
            this.btnSPIInit.TabIndex = 4;
            this.btnSPIInit.Text = "Initialize";
            this.btnSPIInit.UseVisualStyleBackColor = true;
            this.btnSPIInit.Click += new System.EventHandler(this.btnSPIInit_Click);
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.tblDevCmd);
            this.tabOutput.Location = new System.Drawing.Point(4, 25);
            this.tabOutput.Margin = new System.Windows.Forms.Padding(4);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(4);
            this.tabOutput.Size = new System.Drawing.Size(1013, 511);
            this.tabOutput.TabIndex = 2;
            this.tabOutput.Text = "Device";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // tblDevCmd
            // 
            this.tblDevCmd.ColumnCount = 6;
            this.tblDevCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDevCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tblDevCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tblDevCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tblDevCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tblDevCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDevCmd.Controls.Add(this.lbDevTitle, 0, 0);
            this.tblDevCmd.Controls.Add(this.btnDevReset, 1, 1);
            this.tblDevCmd.Controls.Add(this.chkDevClosedLp, 1, 2);
            this.tblDevCmd.Controls.Add(this.label1, 1, 3);
            this.tblDevCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDevCmd.Location = new System.Drawing.Point(3, 3);
            this.tblDevCmd.Margin = new System.Windows.Forms.Padding(2);
            this.tblDevCmd.Name = "tblDevCmd";
            this.tblDevCmd.RowCount = 7;
            this.tblDevCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0034F));
            this.tblDevCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33527F));
            this.tblDevCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33226F));
            this.tblDevCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33226F));
            this.tblDevCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33226F));
            this.tblDevCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33226F));
            this.tblDevCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33226F));
            this.tblDevCmd.Size = new System.Drawing.Size(752, 373);
            this.tblDevCmd.TabIndex = 0;
            // 
            // lbDevTitle
            // 
            this.lbDevTitle.AutoSize = true;
            this.tblDevCmd.SetColumnSpan(this.lbDevTitle, 2);
            this.lbDevTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDevTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDevTitle.Location = new System.Drawing.Point(2, 0);
            this.lbDevTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDevTitle.Name = "lbDevTitle";
            this.lbDevTitle.Size = new System.Drawing.Size(297, 74);
            this.lbDevTitle.TabIndex = 0;
            this.lbDevTitle.Text = "Device Control Panel";
            this.lbDevTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDevReset
            // 
            this.btnDevReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDevReset.Location = new System.Drawing.Point(228, 76);
            this.btnDevReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnDevReset.Name = "btnDevReset";
            this.btnDevReset.Size = new System.Drawing.Size(71, 45);
            this.btnDevReset.TabIndex = 1;
            this.btnDevReset.Text = "Reset";
            this.btnDevReset.UseVisualStyleBackColor = true;
            // 
            // chkDevClosedLp
            // 
            this.chkDevClosedLp.AutoSize = true;
            this.tblDevCmd.SetColumnSpan(this.chkDevClosedLp, 2);
            this.chkDevClosedLp.Location = new System.Drawing.Point(228, 125);
            this.chkDevClosedLp.Margin = new System.Windows.Forms.Padding(2);
            this.chkDevClosedLp.Name = "chkDevClosedLp";
            this.chkDevClosedLp.Size = new System.Drawing.Size(90, 16);
            this.chkDevClosedLp.TabIndex = 2;
            this.chkDevClosedLp.Text = "Closed Loop";
            this.chkDevClosedLp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Read ";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(595, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 31);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close (&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(451, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save (&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // FrmSPIConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSPIConfig";
            this.Text = "SPI Config";
            this.Load += new System.EventHandler(this.FrmSPIConfig_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabGen.ResumeLayout(false);
            this.tblGeneral.ResumeLayout(false);
            this.tblGeneral.PerformLayout();
            this.tabSPICfg.ResumeLayout(false);
            this.tblSPICfg.ResumeLayout(false);
            this.tblSPICfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClkDiv)).EndInit();
            this.tabOutput.ResumeLayout(false);
            this.tblDevCmd.ResumeLayout(false);
            this.tblDevCmd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabConfig;
        private System.Windows.Forms.TabPage tabGen;
        private System.Windows.Forms.TabPage tabSPICfg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TableLayoutPanel tblGeneral;
        private System.Windows.Forms.Label lbGeDev;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Button btnDevRefresh;
        private System.Windows.Forms.Label lbGeOp;
        private System.Windows.Forms.Label lbGeOpened;
        private System.Windows.Forms.Label lbGeIDII;
        private System.Windows.Forms.Label lbGeID;
        private System.Windows.Forms.Label lbGeLocIDII;
        private System.Windows.Forms.Label lbGeLocID;
        private System.Windows.Forms.Label lbGeSNII;
        private System.Windows.Forms.Label lbGeSN;
        private System.Windows.Forms.Label lbGeDescII;
        private System.Windows.Forms.Label lbGeDesc;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TableLayoutPanel tblSPICfg;
        private System.Windows.Forms.Label lbSPClkDiv;
        private System.Windows.Forms.NumericUpDown numClkDiv;
        private System.Windows.Forms.Label lbSPIFreqll;
        private System.Windows.Forms.Label lbSPIFreq;
        private System.Windows.Forms.Button btnSPIInit;
        private System.Windows.Forms.TableLayoutPanel tblDevCmd;
        private System.Windows.Forms.Label lbDevTitle;
        private System.Windows.Forms.Button btnDevReset;
        private System.Windows.Forms.CheckBox chkDevClosedLp;
        private System.Windows.Forms.Label label1;
    }
}