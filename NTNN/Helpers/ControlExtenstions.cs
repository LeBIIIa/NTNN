using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTNN.Helpers
{
    public static class ControlExtenstions
    {
        public static void ToolStripStatusInvokeAction<TControlType>( this TControlType control, Action<TControlType> del )
            where TControlType : ToolStripItem
        {
            if (control.GetCurrentParent().InvokeRequired)
                control.GetCurrentParent().Invoke(new Action(() => del(control)));
            else
                del(control);
        }
        public static void ControlInvokeAction<TControlType>( this TControlType control, Action<TControlType> del )
            where TControlType : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => del(control)));
            else
                del(control);
        }
    }
}
