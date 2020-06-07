namespace NTNN
{
    partial class ShowInfoForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpPC = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblPCHost = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPCIP = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCPU = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pbCPU = new System.Windows.Forms.ProgressBar();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblRAM = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pbRAM = new System.Windows.Forms.ProgressBar();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblDisk = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pbDisk = new System.Windows.Forms.ProgressBar();
            this.CPU_RAM_usage = new LiveCharts.WinForms.CartesianChart();
            this.tpRouter = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tpSwitch = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.tpPC.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tpRouter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpPC);
            this.tabControl.Controls.Add(this.tpRouter);
            this.tabControl.Controls.Add(this.tpSwitch);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1010, 329);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // tpPC
            // 
            this.tpPC.Controls.Add(this.tableLayoutPanel2);
            this.tpPC.Location = new System.Drawing.Point(4, 25);
            this.tpPC.Name = "tpPC";
            this.tpPC.Padding = new System.Windows.Forms.Padding(3);
            this.tpPC.Size = new System.Drawing.Size(1002, 300);
            this.tpPC.TabIndex = 0;
            this.tpPC.Text = "PC";
            this.tpPC.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CPU_RAM_usage, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(996, 294);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.panel8);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.panel7);
            this.flowLayoutPanel2.Controls.Add(this.panel9);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(301, 288);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel8.Controls.Add(this.lblPCHost);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.lblPCIP);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(105, 46);
            this.panel8.TabIndex = 5;
            // 
            // lblPCHost
            // 
            this.lblPCHost.AutoSize = true;
            this.lblPCHost.Location = new System.Drawing.Point(83, 26);
            this.lblPCHost.Margin = new System.Windows.Forms.Padding(3);
            this.lblPCHost.Name = "lblPCHost";
            this.lblPCHost.Size = new System.Drawing.Size(19, 17);
            this.lblPCHost.TabIndex = 3;
            this.lblPCHost.Text = "ip";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 26);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "Hostname:";
            // 
            // lblPCIP
            // 
            this.lblPCIP.AutoSize = true;
            this.lblPCIP.Location = new System.Drawing.Point(36, 3);
            this.lblPCIP.Margin = new System.Windows.Forms.Padding(3);
            this.lblPCIP.Name = "lblPCIP";
            this.lblPCIP.Size = new System.Drawing.Size(19, 17);
            this.lblPCIP.TabIndex = 1;
            this.lblPCIP.Text = "ip";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 3);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "IP:";
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Controls.Add(this.lblCPU);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.pbCPU);
            this.panel6.Location = new System.Drawing.Point(3, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(291, 36);
            this.panel6.TabIndex = 6;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(260, 10);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(28, 17);
            this.lblCPU.TabIndex = 2;
            this.lblCPU.Text = "0%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "CPU:";
            // 
            // pbCPU
            // 
            this.pbCPU.Location = new System.Drawing.Point(50, 3);
            this.pbCPU.Name = "pbCPU";
            this.pbCPU.Size = new System.Drawing.Size(204, 30);
            this.pbCPU.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.Controls.Add(this.lblRAM);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.pbRAM);
            this.panel7.Location = new System.Drawing.Point(3, 97);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(291, 36);
            this.panel7.TabIndex = 7;
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(260, 10);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(28, 17);
            this.lblRAM.TabIndex = 2;
            this.lblRAM.Text = "0%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "RAM:";
            // 
            // pbRAM
            // 
            this.pbRAM.Location = new System.Drawing.Point(50, 3);
            this.pbRAM.Name = "pbRAM";
            this.pbRAM.Size = new System.Drawing.Size(204, 30);
            this.pbRAM.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel9.Controls.Add(this.lblDisk);
            this.panel9.Controls.Add(this.label18);
            this.panel9.Controls.Add(this.pbDisk);
            this.panel9.Location = new System.Drawing.Point(3, 139);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(295, 36);
            this.panel9.TabIndex = 8;
            // 
            // lblDisk
            // 
            this.lblDisk.AutoSize = true;
            this.lblDisk.Location = new System.Drawing.Point(260, 10);
            this.lblDisk.Name = "lblDisk";
            this.lblDisk.Size = new System.Drawing.Size(32, 17);
            this.lblDisk.TabIndex = 2;
            this.lblDisk.Text = "0 %";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 17);
            this.label18.TabIndex = 1;
            this.label18.Text = "Disk:";
            // 
            // pbDisk
            // 
            this.pbDisk.Location = new System.Drawing.Point(50, 3);
            this.pbDisk.Name = "pbDisk";
            this.pbDisk.Size = new System.Drawing.Size(204, 30);
            this.pbDisk.TabIndex = 0;
            // 
            // CPU_RAM_usage
            // 
            this.CPU_RAM_usage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPU_RAM_usage.Location = new System.Drawing.Point(310, 3);
            this.CPU_RAM_usage.Name = "CPU_RAM_usage";
            this.CPU_RAM_usage.Size = new System.Drawing.Size(683, 288);
            this.CPU_RAM_usage.TabIndex = 2;
            this.CPU_RAM_usage.Text = "cartesianChart1";
            // 
            // tpRouter
            // 
            this.tpRouter.Controls.Add(this.groupBox1);
            this.tpRouter.Location = new System.Drawing.Point(4, 25);
            this.tpRouter.Name = "tpRouter";
            this.tpRouter.Padding = new System.Windows.Forms.Padding(3);
            this.tpRouter.Size = new System.Drawing.Size(1002, 300);
            this.tpRouter.TabIndex = 1;
            this.tpRouter.Text = "Router";
            this.tpRouter.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 294);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Routing table";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 18);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(990, 273);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tpSwitch
            // 
            this.tpSwitch.Location = new System.Drawing.Point(4, 25);
            this.tpSwitch.Name = "tpSwitch";
            this.tpSwitch.Padding = new System.Windows.Forms.Padding(3);
            this.tpSwitch.Size = new System.Drawing.Size(1002, 300);
            this.tpSwitch.TabIndex = 2;
            this.tpSwitch.Text = "Switch";
            this.tpSwitch.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1016, 335);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // ShowInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 335);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "ShowInfoForm";
            this.Text = "ShowInfoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.ShowInfoForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tpPC.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tpRouter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpPC;
        private System.Windows.Forms.TabPage tpRouter;
        private System.Windows.Forms.TabPage tpSwitch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblPCHost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPCIP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar pbCPU;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar pbRAM;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblDisk;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ProgressBar pbDisk;
        private LiveCharts.WinForms.CartesianChart CPU_RAM_usage;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}