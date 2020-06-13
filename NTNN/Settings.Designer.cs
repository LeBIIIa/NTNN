namespace NTNN
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && ( components != null ))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericTimeout = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericAttempts = new System.Windows.Forms.NumericUpDown();
            this.cbMonitoring = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotifyEmail = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numCPU = new System.Windows.Forms.NumericUpDown();
            this.numRAM = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttempts)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAM)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(4, 275);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.MinimumSize = new System.Drawing.Size(67, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(371, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(373, 160);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 308);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbMonitoring, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 123);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(371, 263);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericTimeout);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 67);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.MinimumSize = new System.Drawing.Size(267, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(363, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timeout(ms)";
            // 
            // numericTimeout
            // 
            this.numericTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTimeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericTimeout.Location = new System.Drawing.Point(4, 19);
            this.numericTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericTimeout.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numericTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(355, 22);
            this.numericTimeout.TabIndex = 0;
            this.numericTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericAttempts);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.MinimumSize = new System.Drawing.Size(267, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(363, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attempts";
            // 
            // numericAttempts
            // 
            this.numericAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericAttempts.Location = new System.Drawing.Point(4, 19);
            this.numericAttempts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAttempts.Name = "numericAttempts";
            this.numericAttempts.Size = new System.Drawing.Size(355, 22);
            this.numericAttempts.TabIndex = 0;
            this.numericAttempts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbMonitoring
            // 
            this.cbMonitoring.AutoSize = true;
            this.cbMonitoring.Location = new System.Drawing.Point(3, 129);
            this.cbMonitoring.Name = "cbMonitoring";
            this.cbMonitoring.Size = new System.Drawing.Size(264, 21);
            this.cbMonitoring.TabIndex = 2;
            this.cbMonitoring.Text = "Enable monitoring registered devices";
            this.cbMonitoring.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.txtNotifyEmail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 28);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notify email to:";
            // 
            // txtNotifyEmail
            // 
            this.txtNotifyEmail.Location = new System.Drawing.Point(112, 3);
            this.txtNotifyEmail.Name = "txtNotifyEmail";
            this.txtNotifyEmail.Size = new System.Drawing.Size(248, 22);
            this.txtNotifyEmail.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 190);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(365, 70);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.numCPU);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 29);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Critical CPU value:";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.numRAM);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 29);
            this.panel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Critical RAM value:";
            // 
            // numCPU
            // 
            this.numCPU.Location = new System.Drawing.Point(137, 4);
            this.numCPU.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCPU.Name = "numCPU";
            this.numCPU.Size = new System.Drawing.Size(220, 22);
            this.numCPU.TabIndex = 2;
            this.numCPU.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numRAM
            // 
            this.numRAM.Location = new System.Drawing.Point(137, 4);
            this.numRAM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRAM.Name = "numRAM";
            this.numRAM.Size = new System.Drawing.Size(220, 22);
            this.numRAM.TabIndex = 3;
            this.numRAM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 308);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(397, 206);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericAttempts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericTimeout;
        private System.Windows.Forms.NumericUpDown numericAttempts;
        private System.Windows.Forms.CheckBox cbMonitoring;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNotifyEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCPU;
        private System.Windows.Forms.NumericUpDown numRAM;
    }
}