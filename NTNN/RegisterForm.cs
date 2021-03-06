﻿using GNS3_API.Helpers;

using NTNN.Helpers;

using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace NTNN
{
    public partial class RegisterForm : Form
    {
        TypeOfWork currWork;
        int RegisteredDevicePK;

        public RegisterForm(TypeOfWork work, NameValueCollection nameValueCollection)
        {
            InitializeComponent();

            try
            {
                foreach (var strDeviceType in Enum.GetNames(typeof(DeviceType)))
                {
                    cbType.Items.Add(strDeviceType);
                }

                currWork = work;

                switch (work)
                {
                    case TypeOfWork.UpdateDevice:
                        txtIP.Enabled = false;
                        txtHostname.Enabled = true;
                        break;
                    case TypeOfWork.FromScannedDevice:
                        txtIP.Enabled = false;
                        txtHostname.Enabled = false;
                        break;
                }

                foreach (var val in nameValueCollection.AllKeys)
                {
                    switch (val)
                    {
                        case "RegisteredDevicePK":
                            RegisteredDevicePK = int.Parse(nameValueCollection["RegisteredDevicePK"]);
                            break;
                        case "IP":
                            txtIP.Text = nameValueCollection["IP"];
                            break;
                        case "Name":
                            txtName.Text = nameValueCollection["Name"];
                            break;
                        case "Hostname":
                            txtHostname.Text = nameValueCollection["Hostname"];
                            break;
                        case "Type":
                            cbType.SelectedItem = nameValueCollection["Type"];
                            break;
                        case "Port":
                            numPort.Value = int.Parse(nameValueCollection["Port"]);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error occur! Check log file");
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
            }
        }

        private void btnAddORSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IPAddress.TryParse(txtIP.Text, out _))
                {
                    MessageBox.Show("IP address is incorrect!");
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHostname.Text))
                {
                    MessageBox.Show("Hostname/Name cannot be empty!");
                    return;
                }
                if (cbType.SelectedItem == null)
                {
                    MessageBox.Show("Select type, it cannot be empty!");
                    return;
                }

                var type = (DeviceType)Enum.Parse(typeof(DeviceType), cbType.SelectedItem.ToString());
                bool? ret = null;
                switch (currWork)
                {
                    case TypeOfWork.FromScannedDevice:
                    case TypeOfWork.AddDevice:
                        RegisteredDevice.AddRegisteredDevice(txtIP.Text, txtName.Text, txtHostname.Text, type, (short)numPort.Value);
                        break;
                    case TypeOfWork.UpdateDevice:
                        ret = RegisteredDevice.UpdateRegisteredDevice(txtName.Text, type, (short)numPort.Value, RegisteredDevicePK);
                        break;
                }
                if (ret == null)
                    DialogResult = DialogResult.OK;
                if (ret != null && ret == true)
                    DialogResult = DialogResult.OK;
                else if (ret != null && ret == false)
                    MessageBox.Show("Internal error! Could not update device!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Internal error! {ex.Message}");
            }
        }
    }
}
