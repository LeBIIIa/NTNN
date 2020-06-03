using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;

using NTNN.Helpers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTNN
{
    public partial class ShowInfoForm : Form
    {
        RegisteredDevice device;

        public ShowInfoForm(RegisteredDevice device)
        {
            InitializeComponent();
            this.device = device;

            switch (device.Type)
            {
                case DeviceType.PC:
                    tabControl.SelectedTab = tpPC;
                    break;
                case DeviceType.Router:
                    tabControl.SelectedTab = tpRouter;
                    break;
                case DeviceType.Switch:
                    tabControl.SelectedTab = tpSwitch;
                    break;
                case DeviceType.Printer:
                    tabControl.SelectedTab = tpPrinter;
                    break;
                default:
                    {
                        MessageBox.Show("Incorrect device type!");
                        DialogResult = DialogResult.Abort;
                        break;
                    }
            }
        }

        private void tabControl_Selecting( object sender, TabControlCancelEventArgs e )
        {
            e.Cancel = true;
        }

        private void ShowInfoForm_Load( object sender, EventArgs e )
        {
            GetDeviceType(device.Type, device.GetIPAddress);
        }

        public static bool GetDeviceType(DeviceType deviceType, IPAddress iP)
        {
            var lst = new List<Variable>();
            switch (deviceType)
            {
                case DeviceType.Printer:
                    lst.Add(new Variable(new ObjectIdentifier("1.3.6.1.2.1.43.5.1.1.1.1")));
                    break;
                case DeviceType.Router:
                    lst.Add(new Variable(new ObjectIdentifier("1.3.6.1.2.1.4.1.0")));
                    break;
                case DeviceType.Switch:
                    lst.Add(new Variable(new ObjectIdentifier("1.3.6.1.2.1.17.1.2.0")));
                    lst.Add(new Variable(new ObjectIdentifier("1.3.6.1.2.1.4.1.0")));
                    break;
                case DeviceType.PC:
                    return true;
            }

            GetRequestMessage request = new GetRequestMessage(
                Messenger.NextMessageId, 
                VersionCode.V2, 
                new OctetString("public"), 
                lst);
            ISnmpMessage reply = request.GetResponse(10000, new IPEndPoint(iP, 161));
            if (reply.Pdu().ErrorStatus.ToInt32() != 0) // != ErrorCode.NoError
            {
                throw ErrorException.Create(
                    "error in response",
                    IPAddress.Parse("192.168.1.2"),
                    reply);
            }
            return false;
        }
    }
}
