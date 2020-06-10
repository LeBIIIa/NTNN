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
        Thread thread;

        public RegisterForm(TypeOfWork work, NameValueCollection nameValueCollection)
        {
            InitializeComponent();

            foreach (var strDeviceType in Enum.GetNames(typeof(DeviceType)))
            {
                cbType.Items.Add(strDeviceType);
            }

            currWork = work;

            foreach (var val in nameValueCollection.AllKeys)
            {
                switch (val)
                {
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
                    case "RegisteredDevicePK":
                        RegisteredDevicePK = int.Parse(nameValueCollection["RegisteredDevicePK"]);
                        break;
                }
            }

            switch (work)
            {
                case TypeOfWork.AddDevice:
                    txtIP.Enabled = true;
                    break;
                case TypeOfWork.UpdateDevice:
                    txtIP.Enabled = false;
                    break;
                case TypeOfWork.FromScannedDevice:
                    txtIP.Enabled = false;
                    break;
            }
        }

        private void btnAddORSave_Click(object sender, EventArgs e)
        {
            btnAddORSave.Enabled = false;
            try
            {
                if (!IPAddress.TryParse(txtIP.Text, out _))
                {
                    MessageBox.Show("IP address is incorrect!");
                    return;
                }
                if (string.IsNullOrEmpty(txtHostname.Text))
                {
                    if (thread == null || (thread != null && thread.ThreadState == ThreadState.Stopped))
                    {
                        thread = new Thread(() =>
                        {
                            var host = BackgroundWorkerObject.GetHostName(txtIP.Text);
                            txtHostname.ControlInvokeAction(hostname =>
                            {
                                hostname.Text = host;
                            });
                        });
                        thread.Start();
                    }
                    MessageBox.Show("Identifying hostname...");
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Name cannot be empty!");
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
                        RegisteredDevice.AddRegisteredDevice(txtIP.Text, txtName.Text, txtHostname.Text, type);
                        break;
                    case TypeOfWork.UpdateDevice:
                        ret = RegisteredDevice.UpdateRegisteredDevice(txtName.Text, type, RegisteredDevicePK);
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
            btnAddORSave.Enabled = true;
        }
    }
}
