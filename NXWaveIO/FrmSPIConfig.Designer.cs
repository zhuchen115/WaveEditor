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
            this.tabSPICfg = new System.Windows.Forms.TabPage();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tabGen.SuspendLayout();
            this.tblGeneral.SuspendLayout();
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
            // tabSPICfg
            // 
            this.tabSPICfg.Location = new System.Drawing.Point(4, 22);
            this.tabSPICfg.Name = "tabSPICfg";
            this.tabSPICfg.Padding = new System.Windows.Forms.Padding(3);
            this.tabSPICfg.Size = new System.Drawing.Size(758, 379);
            this.tabSPICfg.TabIndex = 1;
            this.tabSPICfg.Text = "SPI";
            this.tabSPICfg.UseVisualStyleBackColor = true;
            // 
            // tabOutput
            // 
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(758, 379);
            this.tabOutput.TabIndex = 2;
            this.tabOutput.Text = "Device";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(446, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close (&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(338, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save (&S)";
            this.btnSave.UseVisualStyleBackColor = true;
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
            // FrmSPIConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSPIConfig";
            this.Text = "SPI Config";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabGen.ResumeLayout(false);
            this.tblGeneral.ResumeLayout(false);
            this.tblGeneral.PerformLayout();
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
    }
}