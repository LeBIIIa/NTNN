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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowInfoForm));
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
            this.label2 = new System.Windows.Forms.Label();
            this.pbRAM = new System.Windows.Forms.ProgressBar();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblDisk = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pbDisk = new System.Windows.Forms.ProgressBar();
            this.CPU_RAM_usage = new LiveCharts.WinForms.CartesianChart();
            this.tpRouter = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSysInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.lblHostRouter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIPRouter = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCPURouter = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pbCPURouter = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDiskRouter = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbDiskRouter = new System.Windows.Forms.ProgressBar();
            this.lstInterfaces = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpSwitch = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpPC);
            this.tabControl.Controls.Add(this.tpRouter);
            this.tabControl.Controls.Add(this.tpSwitch);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(2, 2);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(642, 268);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // tpPC
            // 
            this.tpPC.Controls.Add(this.tableLayoutPanel2);
            this.tpPC.Location = new System.Drawing.Point(4, 22);
            this.tpPC.Margin = new System.Windows.Forms.Padding(2);
            this.tpPC.Name = "tpPC";
            this.tpPC.Padding = new System.Windows.Forms.Padding(2);
            this.tpPC.Size = new System.Drawing.Size(634, 242);
            this.tpPC.TabIndex = 0;
            this.tpPC.Text = "PC";
            this.tpPC.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CPU_RAM_usage, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(630, 238);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.flowLayoutPanel2.Size = new System.Drawing.Size(300, 232);
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
            this.panel8.Size = new System.Drawing.Size(87, 42);
            this.panel8.TabIndex = 5;
            // 
            // lblPCHost
            // 
            this.lblPCHost.AutoSize = true;
            this.lblPCHost.Location = new System.Drawing.Point(69, 26);
            this.lblPCHost.Margin = new System.Windows.Forms.Padding(3);
            this.lblPCHost.Name = "lblPCHost";
            this.lblPCHost.Size = new System.Drawing.Size(15, 13);
            this.lblPCHost.TabIndex = 3;
            this.lblPCHost.Text = "ip";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 26);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Hostname:";
            // 
            // lblPCIP
            // 
            this.lblPCIP.AutoSize = true;
            this.lblPCIP.Location = new System.Drawing.Point(32, 3);
            this.lblPCIP.Margin = new System.Windows.Forms.Padding(3);
            this.lblPCIP.Name = "lblPCIP";
            this.lblPCIP.Size = new System.Drawing.Size(15, 13);
            this.lblPCIP.TabIndex = 1;
            this.lblPCIP.Text = "ip";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 3);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
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
            this.panel6.Location = new System.Drawing.Point(3, 51);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(284, 36);
            this.panel6.TabIndex = 6;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(260, 10);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(21, 13);
            this.lblCPU.TabIndex = 2;
            this.lblCPU.Text = "0%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
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
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.pbRAM);
            this.panel7.Location = new System.Drawing.Point(3, 93);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(284, 36);
            this.panel7.TabIndex = 7;
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(260, 10);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(21, 13);
            this.lblRAM.TabIndex = 2;
            this.lblRAM.Text = "0%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "RAM:";
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
            this.panel9.Location = new System.Drawing.Point(3, 135);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(294, 36);
            this.panel9.TabIndex = 8;
            // 
            // lblDisk
            // 
            this.lblDisk.AutoSize = true;
            this.lblDisk.Location = new System.Drawing.Point(267, 10);
            this.lblDisk.Name = "lblDisk";
            this.lblDisk.Size = new System.Drawing.Size(24, 13);
            this.lblDisk.TabIndex = 2;
            this.lblDisk.Text = "0 %";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Storage:";
            // 
            // pbDisk
            // 
            this.pbDisk.Location = new System.Drawing.Point(57, 3);
            this.pbDisk.Name = "pbDisk";
            this.pbDisk.Size = new System.Drawing.Size(204, 30);
            this.pbDisk.TabIndex = 0;
            // 
            // CPU_RAM_usage
            // 
            this.CPU_RAM_usage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPU_RAM_usage.Location = new System.Drawing.Point(309, 3);
            this.CPU_RAM_usage.Name = "CPU_RAM_usage";
            this.CPU_RAM_usage.Size = new System.Drawing.Size(318, 232);
            this.CPU_RAM_usage.TabIndex = 2;
            this.CPU_RAM_usage.Text = "cartesianChart1";
            // 
            // tpRouter
            // 
            this.tpRouter.Controls.Add(this.tableLayoutPanel1);
            this.tpRouter.Location = new System.Drawing.Point(4, 22);
            this.tpRouter.Margin = new System.Windows.Forms.Padding(2);
            this.tpRouter.Name = "tpRouter";
            this.tpRouter.Padding = new System.Windows.Forms.Padding(2);
            this.tpRouter.Size = new System.Drawing.Size(653, 242);
            this.tpRouter.TabIndex = 1;
            this.tpRouter.Text = "Router";
            this.tpRouter.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstInterfaces, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 238);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(241, 234);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.lblSysInfo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblUptime);
            this.panel1.Controls.Add(this.lblHostRouter);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblIPRouter);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 70);
            this.panel1.TabIndex = 5;
            // 
            // lblSysInfo
            // 
            this.lblSysInfo.AutoSize = true;
            this.lblSysInfo.Location = new System.Drawing.Point(73, 38);
            this.lblSysInfo.Margin = new System.Windows.Forms.Padding(2);
            this.lblSysInfo.Name = "lblSysInfo";
            this.lblSysInfo.Size = new System.Drawing.Size(24, 13);
            this.lblSysInfo.TabIndex = 7;
            this.lblSysInfo.Text = "text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "System Info:";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(51, 55);
            this.lblUptime.Margin = new System.Windows.Forms.Padding(2);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(24, 13);
            this.lblUptime.TabIndex = 5;
            this.lblUptime.Text = "text";
            // 
            // lblHostRouter
            // 
            this.lblHostRouter.AutoSize = true;
            this.lblHostRouter.Location = new System.Drawing.Point(66, 21);
            this.lblHostRouter.Margin = new System.Windows.Forms.Padding(2);
            this.lblHostRouter.Name = "lblHostRouter";
            this.lblHostRouter.Size = new System.Drawing.Size(15, 13);
            this.lblHostRouter.TabIndex = 3;
            this.lblHostRouter.Text = "ip";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Uptime:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hostname:";
            // 
            // lblIPRouter
            // 
            this.lblIPRouter.AutoSize = true;
            this.lblIPRouter.Location = new System.Drawing.Point(28, 4);
            this.lblIPRouter.Margin = new System.Windows.Forms.Padding(2);
            this.lblIPRouter.Name = "lblIPRouter";
            this.lblIPRouter.Size = new System.Drawing.Size(15, 13);
            this.lblIPRouter.TabIndex = 1;
            this.lblIPRouter.Text = "ip";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "IP:";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.lblCPURouter);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.pbCPURouter);
            this.panel2.Location = new System.Drawing.Point(2, 76);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 28);
            this.panel2.TabIndex = 6;
            // 
            // lblCPURouter
            // 
            this.lblCPURouter.AutoSize = true;
            this.lblCPURouter.Location = new System.Drawing.Point(195, 8);
            this.lblCPURouter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCPURouter.Name = "lblCPURouter";
            this.lblCPURouter.Size = new System.Drawing.Size(21, 13);
            this.lblCPURouter.TabIndex = 2;
            this.lblCPURouter.Text = "0%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "CPU:";
            // 
            // pbCPURouter
            // 
            this.pbCPURouter.Location = new System.Drawing.Point(38, 2);
            this.pbCPURouter.Margin = new System.Windows.Forms.Padding(2);
            this.pbCPURouter.Name = "pbCPURouter";
            this.pbCPURouter.Size = new System.Drawing.Size(153, 24);
            this.pbCPURouter.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.lblDiskRouter);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.pbDiskRouter);
            this.panel3.Location = new System.Drawing.Point(2, 108);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 28);
            this.panel3.TabIndex = 8;
            // 
            // lblDiskRouter
            // 
            this.lblDiskRouter.AutoSize = true;
            this.lblDiskRouter.Location = new System.Drawing.Point(211, 8);
            this.lblDiskRouter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiskRouter.Name = "lblDiskRouter";
            this.lblDiskRouter.Size = new System.Drawing.Size(24, 13);
            this.lblDiskRouter.TabIndex = 2;
            this.lblDiskRouter.Text = "0 %";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Storage:";
            // 
            // pbDiskRouter
            // 
            this.pbDiskRouter.Location = new System.Drawing.Point(54, 2);
            this.pbDiskRouter.Margin = new System.Windows.Forms.Padding(2);
            this.pbDiskRouter.Name = "pbDiskRouter";
            this.pbDiskRouter.Size = new System.Drawing.Size(153, 24);
            this.pbDiskRouter.TabIndex = 0;
            // 
            // lstInterfaces
            // 
            this.lstInterfaces.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstInterfaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInterfaces.HideSelection = false;
            this.lstInterfaces.Location = new System.Drawing.Point(248, 3);
            this.lstInterfaces.Name = "lstInterfaces";
            this.lstInterfaces.Size = new System.Drawing.Size(398, 232);
            this.lstInterfaces.TabIndex = 2;
            this.lstInterfaces.UseCompatibleStateImageBehavior = false;
            this.lstInterfaces.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Interface";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "In";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Out";
            // 
            // tpSwitch
            // 
            this.tpSwitch.Location = new System.Drawing.Point(4, 22);
            this.tpSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.tpSwitch.Name = "tpSwitch";
            this.tpSwitch.Padding = new System.Windows.Forms.Padding(2);
            this.tpSwitch.Size = new System.Drawing.Size(628, 242);
            this.tpSwitch.TabIndex = 2;
            this.tpSwitch.Text = "Switch";
            this.tpSwitch.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 242);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Printer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(646, 272);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // ShowInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 272);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShowInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpPC;
        private System.Windows.Forms.TabPage tpRouter;
        private System.Windows.Forms.TabPage tpSwitch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblPCHost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPCIP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar pbCPU;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbRAM;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblDisk;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ProgressBar pbDisk;
        private LiveCharts.WinForms.CartesianChart CPU_RAM_usage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblHostRouter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIPRouter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCPURouter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar pbCPURouter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDiskRouter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pbDiskRouter;
        private System.Windows.Forms.ListView lstInterfaces;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblSysInfo;
        private System.Windows.Forms.Label label3;
    }
}