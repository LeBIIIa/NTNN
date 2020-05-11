using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNN.Extension
{
    public static class Helper
    {
        public static int AttemptsMax = 100;
        public static int AttemptsMin = 1;
        public static int TimeoutMax = 60000;
        public static int TimeoutMin = 1000;
    }

    public class Container
    {
        public int Attempts { get; }
        public int Timeout { get; }
        public string SelectedAdapter { get; }
        public Container()
        {
            Attempts = Properties.Settings.Default.Attempts;
            Timeout = Properties.Settings.Default.Timeout;
            SelectedAdapter = Properties.Settings.Default.SelectedAdapter;
        }
    }

    public enum Status
    {
        Up,
        Down,
        Unstable
    }
}
