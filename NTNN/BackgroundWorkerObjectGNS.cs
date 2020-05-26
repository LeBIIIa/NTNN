using GNS3_API;
using GNS3_API.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTNN
{
    public class BackgroundWorkerObjectGNS
    {
        #region events
        public event Action<int> InitProgressBar;
        public event Action<int> UpdateProgressBar;

        public event Action<SystemCategories, string> SetTextLabel1;
        public event Action<SystemCategories, string> SetTextLabel2;

        public event Func<string, bool> ShowMessageBoxWithResult;

        public event Action UpdateNodesTable;
        public event Action<string> SetNodeStatus;

        public event Action<Button> StartProject;
        public event Action<Button> StopProject;

        public event Func<string> GetSelectedNodeName;
        #endregion

        private readonly SynchronizationContext _synchronizationContext;
        public GNS3sharp Handler { get; private set; }

        private readonly BackgroundWorker bwListener;

        public static readonly string StartText;
        public static readonly string StopText;

        private string projectId, host;
        private ushort port;

        public string ProjectName { get; private set; }

        public BackgroundWorkerObjectGNS( SynchronizationContext context, BackgroundWorker worker )
        {
            _synchronizationContext = context;
            bwListener = worker;
        }

        static BackgroundWorkerObjectGNS()
        {
            StartText = Form1.StartText;
            StopText = Form1.StopText;
        }

        public void SetGns3Data(string projectName, string projectId, string host, ushort port)
        {
            ProjectName = projectName;
            this.projectId = projectId;
            this.host = host;
            this.port = port;
        }

        public void DoWork(object obj)
        {
            if (obj is Button btn)
            {
                switch (btn.Name)
                {
                    case "btnFind":
                        Handler = new GNS3sharp(projectId, SetTextLabel1, host, port);
                        UpdateNodesTable();
                        break;
                    case "btnReloadStatus":
                        Handler.UpdateProject();
                        UpdateNodesTable();
                        break;
                    case "btnStartStop":
                        string text = btn.Text;
                        if (text == StartText)
                        {
                            Handler.StartProject();
                            StartProject(btn);
                            bwListener.RunWorkerAsync();
                        }
                        else if (text == StopText)
                        {
                            var res = ShowMessageWithResult("Are you want to stop all nodes?");
                            if (res)
                                Handler.StopProject();
                            StopProject(btn);
                            bwListener.CancelAsync();
                        }
                        UpdateNodesTable();
                        break;
                }
            }
            else if (obj is ToolStripItem tsi)
            {

                string item = GetSelectedNodeName();
                var selectedNode = Handler.GetNodeByName(item);
                switch (tsi.Name)
                {
                    case "tsStart":
                        Handler.StartNode(selectedNode);
                        break;
                    case "tsStop":
                        Handler.StopNode(selectedNode);
                        break;
                    case "tsReload":
                        Handler.ReloadNode(selectedNode);
                        break;
                    case "tsSuspend" when selectedNode is Router || selectedNode is Switch:
                        Handler.SuspendNode(selectedNode);
                        break;
                    default:
                        MessageBox.Show("Incorrect menu item selected!");
                        break;
                }
                SetNodeStatus(selectedNode.GetStatus);
            }
        }
        private bool ShowMessageWithResult( string text )
        {
            bool ret = false;
            _synchronizationContext.Send(callback => ret = ShowMessageBoxWithResult(text), null);
            return ret;
        }
    }
}
