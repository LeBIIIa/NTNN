namespace NTNN
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.contextMenuScannedDevices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToRegisteredDeviceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRealData = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lstRegisterDevices = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnDelDevice = new System.Windows.Forms.Button();
            this.btnUpdDevice = new System.Windows.Forms.Button();
            this.btnShowDeviceInf = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listVAddr = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MacAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabGNS3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.lstNodes = new System.Windows.Forms.ListView();
            this.columnHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuGNS3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSuspend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReload = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnReloadStatus = new System.Windows.Forms.Button();
            this.btnGraphics = new System.Windows.Forms.Button();
            this.bwGNS3_API = new System.ComponentModel.BackgroundWorker();
            this.bwListener = new System.ComponentModel.BackgroundWorker();
            this.menuStrip = new System.Windows.Forms.ToolStrip();
            this.tsBtnSettings = new System.Windows.Forms.ToolStripButton();
            this.bwCheckDevices = new System.ComponentModel.BackgroundWorker();
            this.txtIP = new NTNN.ExtendedControls.IPAddressControl.IPAddressControl3();
            this.txtUserName = new NTNN.ExtendedControls.WaterMarkTextBox();
            this.txtPassword = new NTNN.ExtendedControls.WaterMarkTextBox();
            this.statusStrip.SuspendLayout();
            this.contextMenuScannedDevices.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabRealData.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabGNS3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuGNS3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus1,
            this.lblStatus2,
            this.toolStripProgressBar});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 536);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip.Size = new System.Drawing.Size(800, 25);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus1
            // 
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(0, 19);
            // 
            // lblStatus2
            // 
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(0, 19);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 17);
            // 
            // contextMenuScannedDevices
            // 
            this.contextMenuScannedDevices.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuScannedDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statsToolStripMenuItem,
            this.addToRegisteredDeviceListToolStripMenuItem});
            this.contextMenuScannedDevices.Name = "contextMenuStrip";
            this.contextMenuScannedDevices.Size = new System.Drawing.Size(270, 52);
            this.contextMenuScannedDevices.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuScannedDevices_Opening);
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(269, 24);
            this.statsToolStripMenuItem.Text = "Stats";
            this.statsToolStripMenuItem.Click += new System.EventHandler(this.StatsToolStripMenuItem_Click);
            // 
            // addToRegisteredDeviceListToolStripMenuItem
            // 
            this.addToRegisteredDeviceListToolStripMenuItem.Name = "addToRegisteredDeviceListToolStripMenuItem";
            this.addToRegisteredDeviceListToolStripMenuItem.Size = new System.Drawing.Size(269, 24);
            this.addToRegisteredDeviceListToolStripMenuItem.Text = "Add to Registered device list";
            this.addToRegisteredDeviceListToolStripMenuItem.Click += new System.EventHandler(this.ToolBtnsForRegisteredDevices_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabRealData);
            this.tabControl.Controls.Add(this.tabGNS3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 31);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 505);
            this.tabControl.TabIndex = 6;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tabRealData
            // 
            this.tabRealData.Controls.Add(this.tableLayoutPanel1);
            this.tabRealData.Location = new System.Drawing.Point(4, 25);
            this.tabRealData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRealData.Name = "tabRealData";
            this.tabRealData.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabRealData.Size = new System.Drawing.Size(792, 476);
            this.tabRealData.TabIndex = 0;
            this.tabRealData.Text = "Real time simulation";
            this.tabRealData.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblError, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 472);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.btnScan);
            this.flowLayoutPanel1.Controls.Add(this.btnStop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 425);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(780, 45);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 35);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Subnet:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "e.g. 10.172.44";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(195, 4);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(100, 36);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.Scan_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(303, 4);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 36);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(780, 249);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registered devices";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lstRegisterDevices, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(774, 230);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // lstRegisterDevices
            // 
            this.lstRegisterDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6});
            this.lstRegisterDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRegisterDevices.FullRowSelect = true;
            this.lstRegisterDevices.GridLines = true;
            this.lstRegisterDevices.HideSelection = false;
            this.lstRegisterDevices.Location = new System.Drawing.Point(4, 43);
            this.lstRegisterDevices.Margin = new System.Windows.Forms.Padding(4);
            this.lstRegisterDevices.MultiSelect = false;
            this.lstRegisterDevices.Name = "lstRegisterDevices";
            this.lstRegisterDevices.Size = new System.Drawing.Size(766, 183);
            this.lstRegisterDevices.TabIndex = 17;
            this.lstRegisterDevices.UseCompatibleStateImageBehavior = false;
            this.lstRegisterDevices.View = System.Windows.Forms.View.Details;
            this.lstRegisterDevices.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstRegisterDevices_ColumnWidthChanging);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PK";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 134;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Hostname";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Port";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.btnAddDevice);
            this.flowLayoutPanel3.Controls.Add(this.btnDelDevice);
            this.flowLayoutPanel3.Controls.Add(this.btnUpdDevice);
            this.flowLayoutPanel3.Controls.Add(this.btnShowDeviceInf);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(768, 33);
            this.flowLayoutPanel3.TabIndex = 18;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.AutoSize = true;
            this.btnAddDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddDevice.Location = new System.Drawing.Point(3, 3);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(88, 27);
            this.btnAddDevice.TabIndex = 0;
            this.btnAddDevice.Text = "Add device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.ToolBtnsForRegisteredDevices_Click);
            // 
            // btnDelDevice
            // 
            this.btnDelDevice.AutoSize = true;
            this.btnDelDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelDevice.Location = new System.Drawing.Point(97, 3);
            this.btnDelDevice.Name = "btnDelDevice";
            this.btnDelDevice.Size = new System.Drawing.Size(104, 27);
            this.btnDelDevice.TabIndex = 1;
            this.btnDelDevice.Text = "Delete device";
            this.btnDelDevice.UseVisualStyleBackColor = true;
            this.btnDelDevice.Click += new System.EventHandler(this.ToolBtnsForRegisteredDevices_Click);
            // 
            // btnUpdDevice
            // 
            this.btnUpdDevice.AutoSize = true;
            this.btnUpdDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdDevice.Location = new System.Drawing.Point(207, 3);
            this.btnUpdDevice.Name = "btnUpdDevice";
            this.btnUpdDevice.Size = new System.Drawing.Size(109, 27);
            this.btnUpdDevice.TabIndex = 2;
            this.btnUpdDevice.Text = "Update device";
            this.btnUpdDevice.UseVisualStyleBackColor = true;
            this.btnUpdDevice.Click += new System.EventHandler(this.ToolBtnsForRegisteredDevices_Click);
            // 
            // btnShowDeviceInf
            // 
            this.btnShowDeviceInf.AutoSize = true;
            this.btnShowDeviceInf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShowDeviceInf.Location = new System.Drawing.Point(322, 3);
            this.btnShowDeviceInf.Name = "btnShowDeviceInf";
            this.btnShowDeviceInf.Size = new System.Drawing.Size(124, 27);
            this.btnShowDeviceInf.TabIndex = 3;
            this.btnShowDeviceInf.Text = "Show device info";
            this.btnShowDeviceInf.UseVisualStyleBackColor = true;
            this.btnShowDeviceInf.Click += new System.EventHandler(this.ToolBtnsForRegisteredDevices_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(3, 1);
            this.lblError.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(780, 17);
            this.lblError.TabIndex = 15;
            this.lblError.Text = "lblError";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listVAddr);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 273);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(780, 148);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scanned devices";
            // 
            // listVAddr
            // 
            this.listVAddr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Hostname,
            this.MacAddress,
            this.Status});
            this.listVAddr.ContextMenuStrip = this.contextMenuScannedDevices;
            this.listVAddr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVAddr.FullRowSelect = true;
            this.listVAddr.GridLines = true;
            this.listVAddr.HideSelection = false;
            this.listVAddr.Location = new System.Drawing.Point(3, 17);
            this.listVAddr.Margin = new System.Windows.Forms.Padding(4);
            this.listVAddr.MultiSelect = false;
            this.listVAddr.Name = "listVAddr";
            this.listVAddr.Size = new System.Drawing.Size(774, 129);
            this.listVAddr.TabIndex = 2;
            this.listVAddr.UseCompatibleStateImageBehavior = false;
            this.listVAddr.View = System.Windows.Forms.View.Details;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 95;
            // 
            // Hostname
            // 
            this.Hostname.Text = "Hostname";
            this.Hostname.Width = 180;
            // 
            // MacAddress
            // 
            this.MacAddress.Text = "MacAddress";
            this.MacAddress.Width = 239;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 50;
            // 
            // tabGNS3
            // 
            this.tabGNS3.Controls.Add(this.tableLayoutPanel5);
            this.tabGNS3.Location = new System.Drawing.Point(4, 25);
            this.tabGNS3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGNS3.Name = "tabGNS3";
            this.tabGNS3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGNS3.Size = new System.Drawing.Size(792, 476);
            this.tabGNS3.TabIndex = 1;
            this.tabGNS3.Text = "GNS3 Simulation";
            this.tabGNS3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lstNodes, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.rtbConsole, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(786, 472);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.btnFind);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(780, 68);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.txtProjectName);
            this.panel2.Controls.Add(this.lblProjectName);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 28);
            this.panel2.TabIndex = 0;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(107, 4);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(161, 22);
            this.txtProjectName.TabIndex = 1;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(3, 6);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(97, 17);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name:";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.txtHost);
            this.panel3.Controls.Add(this.lblHost);
            this.panel3.Location = new System.Drawing.Point(280, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 28);
            this.panel3.TabIndex = 1;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(51, 4);
            this.txtHost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(211, 22);
            this.txtHost.TabIndex = 1;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(3, 6);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(41, 17);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host:";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.txtPort);
            this.panel4.Controls.Add(this.lblPort);
            this.panel4.Location = new System.Drawing.Point(551, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(123, 28);
            this.panel4.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(47, 4);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(73, 22);
            this.txtPort.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(3, 6);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 17);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port:";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.Controls.Add(this.txtUserName);
            this.panel5.Controls.Add(this.lblUserName);
            this.panel5.Location = new System.Drawing.Point(3, 34);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(279, 28);
            this.panel5.TabIndex = 4;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(3, 6);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(81, 17);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User name:";
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txtPassword);
            this.panel6.Location = new System.Drawing.Point(288, 34);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(271, 28);
            this.panel6.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password:";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(566, 36);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(92, 28);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lstNodes
            // 
            this.lstNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHost,
            this.columnPort,
            this.columnName,
            this.columnType,
            this.columnStatus});
            this.lstNodes.ContextMenuStrip = this.contextMenuGNS3;
            this.lstNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNodes.FullRowSelect = true;
            this.lstNodes.HideSelection = false;
            this.lstNodes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lstNodes.Location = new System.Drawing.Point(4, 76);
            this.lstNodes.Margin = new System.Windows.Forms.Padding(4);
            this.lstNodes.MultiSelect = false;
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.Size = new System.Drawing.Size(778, 141);
            this.lstNodes.TabIndex = 1;
            this.lstNodes.UseCompatibleStateImageBehavior = false;
            this.lstNodes.View = System.Windows.Forms.View.Details;
            // 
            // columnHost
            // 
            this.columnHost.Text = "Host";
            this.columnHost.Width = 120;
            // 
            // columnPort
            // 
            this.columnPort.Text = "Port";
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 120;
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            this.columnType.Width = 100;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            // 
            // contextMenuGNS3
            // 
            this.contextMenuGNS3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuGNS3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStart,
            this.tsStop,
            this.tsSuspend,
            this.tsReload});
            this.contextMenuGNS3.Name = "contextMenuStrip1";
            this.contextMenuGNS3.Size = new System.Drawing.Size(275, 100);
            this.contextMenuGNS3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tsStart
            // 
            this.tsStart.Name = "tsStart";
            this.tsStart.Size = new System.Drawing.Size(274, 24);
            this.tsStart.Text = "Start";
            // 
            // tsStop
            // 
            this.tsStop.Name = "tsStop";
            this.tsStop.Size = new System.Drawing.Size(274, 24);
            this.tsStop.Text = "Stop";
            // 
            // tsSuspend
            // 
            this.tsSuspend.Name = "tsSuspend";
            this.tsSuspend.Size = new System.Drawing.Size(274, 24);
            this.tsSuspend.Text = "Suspend(Only for routers, etc)";
            // 
            // tsReload
            // 
            this.tsReload.Name = "tsReload";
            this.tsReload.Size = new System.Drawing.Size(274, 24);
            this.tsReload.Text = "Reload";
            // 
            // rtbConsole
            // 
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConsole.Location = new System.Drawing.Point(4, 265);
            this.rtbConsole.Margin = new System.Windows.Forms.Padding(4);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(778, 203);
            this.rtbConsole.TabIndex = 3;
            this.rtbConsole.Text = "";
            this.rtbConsole.Visible = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.btnStartStop, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnReloadStatus, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnGraphics, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 221);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(786, 40);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.LightGreen;
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStartStop.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnStartStop.FlatAppearance.BorderSize = 0;
            this.btnStartStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartStop.Location = new System.Drawing.Point(707, 4);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 32);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnReloadStatus
            // 
            this.btnReloadStatus.AutoSize = true;
            this.btnReloadStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReloadStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReloadStatus.Enabled = false;
            this.btnReloadStatus.Location = new System.Drawing.Point(593, 2);
            this.btnReloadStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReloadStatus.Name = "btnReloadStatus";
            this.btnReloadStatus.Size = new System.Drawing.Size(107, 36);
            this.btnReloadStatus.TabIndex = 3;
            this.btnReloadStatus.Text = "Reload Status";
            this.btnReloadStatus.UseVisualStyleBackColor = true;
            this.btnReloadStatus.Click += new System.EventHandler(this.btnReloadStatus_Click);
            // 
            // btnGraphics
            // 
            this.btnGraphics.AutoSize = true;
            this.btnGraphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGraphics.Location = new System.Drawing.Point(487, 2);
            this.btnGraphics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGraphics.Name = "btnGraphics";
            this.btnGraphics.Size = new System.Drawing.Size(100, 36);
            this.btnGraphics.TabIndex = 4;
            this.btnGraphics.Text = "Graphics";
            this.btnGraphics.UseVisualStyleBackColor = true;
            this.btnGraphics.Click += new System.EventHandler(this.btnGraphics_Click);
            // 
            // bwGNS3_API
            // 
            this.bwGNS3_API.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGNS3_API_DoWork);
            this.bwGNS3_API.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGNS3_API_RunWorkerCompleted);
            // 
            // bwListener
            // 
            this.bwListener.WorkerSupportsCancellation = true;
            this.bwListener.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwListener_DoWork);
            this.bwListener.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwListener_RunWorkerCompleted);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSettings});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 31);
            this.menuStrip.TabIndex = 16;
            this.menuStrip.Text = "toolStrip1";
            // 
            // tsBtnSettings
            // 
            this.tsBtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSettings.Image = global::NTNN.Properties.Resources.settings;
            this.tsBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSettings.Name = "tsBtnSettings";
            this.tsBtnSettings.Size = new System.Drawing.Size(29, 28);
            this.tsBtnSettings.Text = "toolStripButton1";
            this.tsBtnSettings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // bwCheckDevices
            // 
            this.bwCheckDevices.WorkerSupportsCancellation = true;
            this.bwCheckDevices.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCheckDevices_DoWork);
            // 
            // txtIP
            // 
            this.txtIP.AllowInternalTab = false;
            this.txtIP.AutoHeight = true;
            this.txtIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIP.Location = new System.Drawing.Point(96, 4);
            this.txtIP.Margin = new System.Windows.Forms.Padding(5);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = false;
            this.txtIP.Size = new System.Drawing.Size(84, 22);
            this.txtIP.TabIndex = 5;
            this.txtIP.Text = "..";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtUserName.Location = new System.Drawing.Point(91, 4);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(185, 22);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtUserName.WaterMarkText = "(Optional)";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtPassword.Location = new System.Drawing.Point(83, 4);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 22);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtPassword.WaterMarkText = "(Optional)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "NTNN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuScannedDevices.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabRealData.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabGNS3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.contextMenuGNS3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus2;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus1;
        private System.Windows.Forms.ContextMenuStrip contextMenuScannedDevices;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRealData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listVAddr;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Hostname;
        private System.Windows.Forms.ColumnHeader MacAddress;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TabPage tabGNS3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstNodes;
        private System.Windows.Forms.ColumnHeader columnHost;
        private System.Windows.Forms.ColumnHeader columnPort;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private ExtendedControls.WaterMarkTextBox txtUserName;
        private ExtendedControls.WaterMarkTextBox txtPassword;
        private System.Windows.Forms.ContextMenuStrip contextMenuGNS3;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ToolStripMenuItem tsStart;
        private System.Windows.Forms.ToolStripMenuItem tsStop;
        private System.Windows.Forms.ToolStripMenuItem tsSuspend;
        private System.Windows.Forms.ToolStripMenuItem tsReload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnReloadStatus;
        private System.ComponentModel.BackgroundWorker bwGNS3_API;
        private System.ComponentModel.BackgroundWorker bwListener;
        private System.Windows.Forms.Button btnGraphics;
        private System.Windows.Forms.ToolStrip menuStrip;
        private System.Windows.Forms.ToolStripButton tsBtnSettings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstRegisterDevices;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem addToRegisteredDeviceListToolStripMenuItem;
        private ExtendedControls.IPAddressControl.IPAddressControl3 txtIP;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.ComponentModel.BackgroundWorker bwCheckDevices;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnDelDevice;
        private System.Windows.Forms.Button btnUpdDevice;
        private System.Windows.Forms.Button btnShowDeviceInf;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

