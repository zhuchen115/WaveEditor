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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitCtl)).BeginInit();
            this.splitCtl.Panel1.SuspendLayout();
            this.splitCtl.Panel2.SuspendLayout();
            this.splitCtl.SuspendLayout();
            this.tblPoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitCtl
            // 
            this.splitCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCtl.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitCtl.Location = new System.Drawing.Point(0, 0);
            this.splitCtl.Margin = new System.Windows.Forms.Padding(2);
            this.splitCtl.Name = "splitCtl";
            this.splitCtl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCtl.Panel1
            // 
            this.splitCtl.Panel1.Controls.Add(this.tblPoint);
            // 
            // splitCtl.Panel2
            // 
            this.splitCtl.Panel2.Controls.Add(this.btnCancel);
            this.splitCtl.Panel2.Controls.Add(this.btnSave);
            this.splitCtl.Size = new System.Drawing.Size(443, 218);
            this.splitCtl.SplitterDistance = 167;
            this.splitCtl.SplitterWidth = 3;
            this.splitCtl.TabIndex = 0;
            // 
            // tblPoint
            // 
            this.tblPoint.ColumnCount = 5;
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tblPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblPoint.Controls.Add(this.lbTime, 1, 1);
            this.tblPoint.Controls.Add(this.lbValue, 1, 3);
            this.tblPoint.Controls.Add(this.txtTime, 3, 1);
            this.tblPoint.Controls.Add(this.txtValue, 3, 3);
            this.tblPoint.Controls.Add(this.chkRealTime, 4, 1);
            this.tblPoint.Controls.Add(this.lbIntp, 1, 5);
            this.tblPoint.Controls.Add(this.cmbInterpo, 3, 5);
            this.tblPoint.Controls.Add(this.chkGroup, 4, 5);
            this.tblPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPoint.Location = new System.Drawing.Point(0, 0);
            this.tblPoint.Margin = new System.Windows.Forms.Padding(2);
            this.tblPoint.Name = "tblPoint";
            this.tblPoint.RowCount = 7;
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPoint.Size = new System.Drawing.Size(443, 167);
            this.tblPoint.TabIndex = 0;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(94, 25);
            this.lbTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(81, 22);
            this.lbTime.TabIndex = 7;
            this.lbTime.Text = "Time:";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValue.Location = new System.Drawing.Point(94, 72);
            this.lbValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(81, 22);
            this.lbValue.TabIndex = 8;
            this.lbValue.Text = "Value:";
            this.lbValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTime
            // 
            this.txtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTime.Location = new System.Drawing.Point(199, 27);
            this.txtTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(148, 21);
            this.txtTime.TabIndex = 1;
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleVal_KeyPress);
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(199, 74);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(148, 21);
            this.txtValue.TabIndex = 3;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleVal_KeyPress);
            // 
            // chkRealTime
            // 
            this.chkRealTime.AutoSize = true;
            this.chkRealTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkRealTime.Location = new System.Drawing.Point(351, 27);
            this.chkRealTime.Margin = new System.Windows.Forms.Padding(2);
            this.chkRealTime.Name = "chkRealTime";
            this.chkRealTime.Size = new System.Drawing.Size(90, 18);
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
            this.lbIntp.Location = new System.Drawing.Point(94, 119);
            this.lbIntp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbIntp.Name = "lbIntp";
            this.lbIntp.Size = new System.Drawing.Size(81, 22);
            this.lbIntp.TabIndex = 9;
            this.lbIntp.Text = "Interpolation:";
            this.lbIntp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbInterpo
            // 
            this.cmbInterpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInterpo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterpo.FormattingEnabled = true;
            this.cmbInterpo.Location = new System.Drawing.Point(199, 121);
            this.cmbInterpo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbInterpo.Name = "cmbInterpo";
            this.cmbInterpo.Size = new System.Drawing.Size(148, 20);
            this.cmbInterpo.TabIndex = 10;
            // 
            // chkGroup
            // 
            this.chkGroup.AutoSize = true;
            this.chkGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkGroup.Location = new System.Drawing.Point(351, 121);
            this.chkGroup.Margin = new System.Windows.Forms.Padding(2);
            this.chkGroup.Name = "chkGroup";
            this.chkGroup.Size = new System.Drawing.Size(78, 18);
            this.chkGroup.TabIndex = 11;
            this.chkGroup.Text = "Group (&G)";
            this.chkGroup.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 20);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel (&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(184, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 20);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save (&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 218);
            this.Controls.Add(this.splitCtl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPoint";
            this.Text = "FrmPoint";
            this.Load += new System.EventHandler(this.FrmPoint_Load);
            this.splitCtl.Panel1.ResumeLayout(false);
            this.splitCtl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCtl)).EndInit();
            this.splitCtl.ResumeLayout(false);
            this.tblPoint.ResumeLayout(false);
            this.tblPoint.PerformLayout();
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
    }
}