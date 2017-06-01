namespace WaveEditor
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.tblSet = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisp = new System.Windows.Forms.TextBox();
            this.txtCache = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYName = new System.Windows.Forms.TextBox();
            this.lbWarn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tblSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblSet
            // 
            this.tblSet.ColumnCount = 5;
            this.tblSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSet.Controls.Add(this.label5, 3, 2);
            this.tblSet.Controls.Add(this.label1, 1, 1);
            this.tblSet.Controls.Add(this.label2, 1, 2);
            this.tblSet.Controls.Add(this.txtDisp, 2, 1);
            this.tblSet.Controls.Add(this.txtCache, 2, 2);
            this.tblSet.Controls.Add(this.label3, 1, 3);
            this.tblSet.Controls.Add(this.txtYName, 2, 3);
            this.tblSet.Controls.Add(this.lbWarn, 1, 4);
            this.tblSet.Controls.Add(this.label4, 3, 1);
            this.tblSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSet.Location = new System.Drawing.Point(0, 0);
            this.tblSet.Name = "tblSet";
            this.tblSet.RowCount = 6;
            this.tblSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSet.Size = new System.Drawing.Size(562, 184);
            this.tblSet.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(459, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 30);
            this.label5.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(59, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Display Points :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(59, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bytes of Signal Memory :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDisp
            // 
            this.txtDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDisp.Location = new System.Drawing.Point(259, 35);
            this.txtDisp.Name = "txtDisp";
            this.txtDisp.Size = new System.Drawing.Size(194, 22);
            this.txtDisp.TabIndex = 4;
            this.txtDisp.Text = "100";
            this.txtDisp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntVal_KeyPress);
            // 
            // txtCache
            // 
            this.txtCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCache.Location = new System.Drawing.Point(259, 65);
            this.txtCache.Name = "txtCache";
            this.txtCache.Size = new System.Drawing.Size(194, 22);
            this.txtCache.TabIndex = 5;
            this.txtCache.Text = "268435456";
            this.txtCache.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntVal_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(59, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y Axis Name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtYName
            // 
            this.txtYName.Location = new System.Drawing.Point(259, 95);
            this.txtYName.Name = "txtYName";
            this.txtYName.Size = new System.Drawing.Size(194, 22);
            this.txtYName.TabIndex = 7;
            // 
            // lbWarn
            // 
            this.lbWarn.AutoSize = true;
            this.tblSet.SetColumnSpan(this.lbWarn, 2);
            this.lbWarn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWarn.Image = ((System.Drawing.Image)(resources.GetObject("lbWarn.Image")));
            this.lbWarn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbWarn.Location = new System.Drawing.Point(59, 122);
            this.lbWarn.Name = "lbWarn";
            this.lbWarn.Size = new System.Drawing.Size(394, 30);
            this.lbWarn.TabIndex = 8;
            this.lbWarn.Text = "Changing this value may cause performance issue";
            this.lbWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(459, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 30);
            this.label4.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tblSet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2MinSize = 47;
            this.splitContainer1.Size = new System.Drawing.Size(562, 235);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(562, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(177, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save (&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(284, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel (&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 235);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.tblSet.ResumeLayout(false);
            this.tblSet.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblSet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisp;
        private System.Windows.Forms.TextBox txtCache;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYName;
        private System.Windows.Forms.Label lbWarn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}