namespace WaveEditor
{
    partial class FrmPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPoint));
            this.splitCtl = new System.Windows.Forms.SplitContainer();
            this.tblPoint = new System.Windows.Forms.TableLayoutPanel();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbValue = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.chkRealTime = new System.Windows.Forms.CheckBox();
            this.lbIntp = new System.Windows.Forms.Label();
            this.cmbInterpo = new System.Windows.Forms.ComboBox();
            this.chkGroup = new System.Windows.Forms.CheckBox();
            this.tblFCtrl = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTUnit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitCtl)).BeginInit();
            this.splitCtl.Panel1.SuspendLayout();
            this.splitCtl.Panel2.SuspendLayout();
            this.splitCtl.SuspendLayout();
            this.tblPoint.SuspendLayout();
            this.tblFCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitCtl
            // 
            this.splitCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCtl.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitCtl.IsSplitterFixed = true;
            this.splitCtl.Location = new System.Drawing.Point(0, 0);
            this.splitCtl.Name = "splitCtl";
            this.splitCtl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCtl.Panel1
            // 
            this.splitCtl.Panel1.Controls.Add(this.tblPoint);
            // 
            // splitCtl.Panel2
            // 
            this.splitCtl.Panel2.Controls.Add(this.tblFCtrl);
            this.splitCtl.Panel2MinSize = 47;
            this.splitCtl.Size = new System.Drawing.Size(591, 291);
            this.splitCtl.SplitterDistance = 240;
            this.splitCtl.TabIndex = 0;
            // 
            // tblPoint
            // 
            this.tblPoint.ColumnCount = 7;
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.42633F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.53919F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.03448F));
            this.tblPoint.Controls.Add(this.lbTime, 1, 1);
            this.tblPoint.Controls.Add(this.lbValue, 1, 3);
            this.tblPoint.Controls.Add(this.txtTime, 3, 1);
            this.tblPoint.Controls.Add(this.txtValue, 3, 3);
            this.tblPoint.Controls.Add(this.chkRealTime, 5, 1);
            this.tblPoint.Controls.Add(this.lbIntp, 1, 5);
            this.tblPoint.Controls.Add(this.cmbInterpo, 3, 5);
            this.tblPoint.Controls.Add(this.chkGroup, 5, 5);
            this.tblPoint.Controls.Add(this.lbTUnit, 4, 1);
            this.tblPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPoint.Location = new System.Drawing.Point(0, 0);
            this.tblPoint.Name = "tblPoint";
            this.tblPoint.RowCount = 7;
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.Size = new System.Drawing.Size(591, 240);
            this.tblPoint.TabIndex = 0;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(49, 38);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(107, 29);
            this.lbTime.TabIndex = 7;
            this.lbTime.Text = "Time:";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValue.Location = new System.Drawing.Point(49, 105);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(107, 29);
            this.lbValue.TabIndex = 8;
            this.lbValue.Text = "Value:";
            this.lbValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTime
            // 
            this.txtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTime.Location = new System.Drawing.Point(172, 41);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(197, 22);
            this.txtTime.TabIndex = 1;
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleVal_KeyPress);
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(172, 108);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(197, 22);
            this.txtValue.TabIndex = 3;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleVal_KeyPress);
            // 
            // chkRealTime
            // 
            this.chkRealTime.AutoSize = true;
            this.chkRealTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkRealTime.Location = new System.Drawing.Point(450, 41);
            this.chkRealTime.Name = "chkRealTime";
            this.chkRealTime.Size = new System.Drawing.Size(111, 23);
            this.chkRealTime.TabIndex = 2;
            this.chkRealTime.Text = "Real Time (&T)";
            this.chkRealTime.UseVisualStyleBackColor = true;
            this.chkRealTime.CheckedChanged += new System.EventHandler(this.chkRealTime_CheckedChanged);
            // 
            // lbIntp
            // 
            this.lbIntp.AutoSize = true;
            this.lbIntp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIntp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbIntp.Location = new System.Drawing.Point(49, 172);
            this.lbIntp.Name = "lbIntp";
            this.lbIntp.Size = new System.Drawing.Size(107, 29);
            this.lbIntp.TabIndex = 9;
            this.lbIntp.Text = "Interpolation:";
            this.lbIntp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbInterpo
            // 
            this.cmbInterpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInterpo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterpo.FormattingEnabled = true;
            this.cmbInterpo.Location = new System.Drawing.Point(172, 175);
            this.cmbInterpo.Name = "cmbInterpo";
            this.cmbInterpo.Size = new System.Drawing.Size(197, 24);
            this.cmbInterpo.TabIndex = 10;
            // 
            // chkGroup
            // 
            this.chkGroup.AutoSize = true;
            this.chkGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkGroup.Location = new System.Drawing.Point(450, 175);
            this.chkGroup.Name = "chkGroup";
            this.chkGroup.Size = new System.Drawing.Size(95, 23);
            this.chkGroup.TabIndex = 11;
            this.chkGroup.Text = "Group (&G)";
            this.chkGroup.UseVisualStyleBackColor = true;
            // 
            // tblFCtrl
            // 
            this.tblFCtrl.ColumnCount = 4;
            this.tblFCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tblFCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tblFCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFCtrl.Controls.Add(this.btnCancel, 2, 0);
            this.tblFCtrl.Controls.Add(this.btnSave, 1, 0);
            this.tblFCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFCtrl.Location = new System.Drawing.Point(0, 0);
            this.tblFCtrl.Name = "tblFCtrl";
            this.tblFCtrl.RowCount = 1;
            this.tblFCtrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFCtrl.Size = new System.Drawing.Size(591, 47);
            this.tblFCtrl.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(298, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel (&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(191, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save (&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbTUnit
            // 
            this.lbTUnit.AutoSize = true;
            this.lbTUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTUnit.Location = new System.Drawing.Point(375, 38);
            this.lbTUnit.Name = "lbTUnit";
            this.lbTUnit.Size = new System.Drawing.Size(69, 29);
            this.lbTUnit.TabIndex = 12;
            this.lbTUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 291);
            this.Controls.Add(this.splitCtl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPoint";
            this.Text = "FrmPoint";
            this.Load += new System.EventHandler(this.FrmPoint_Load);
            this.splitCtl.Panel1.ResumeLayout(false);
            this.splitCtl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCtl)).EndInit();
            this.splitCtl.ResumeLayout(false);
            this.tblPoint.ResumeLayout(false);
            this.tblPoint.PerformLayout();
            this.tblFCtrl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitCtl;
        private System.Windows.Forms.TableLayoutPanel tblPoint;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.CheckBox chkRealTime;
        private System.Windows.Forms.Label lbIntp;
        private System.Windows.Forms.ComboBox cmbInterpo;
        private System.Windows.Forms.CheckBox chkGroup;
        private System.Windows.Forms.TableLayoutPanel tblFCtrl;
        private System.Windows.Forms.Label lbTUnit;
    }
}