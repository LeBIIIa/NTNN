// Copyright (c) 2007-2016  Michael Chapman
// https://github.com/m66n/ipaddresscontrollib

// The MIT License (MIT)

// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:

// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


using System.Collections;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace NTNN.ExtendedControls.IPAddressControl
{
  internal class IpAddressControlDesigner : ControlDesigner
  {
    public override SelectionRules SelectionRules
    {
      get
      {
        var control = (IPAddressControl)Control;

        if (control.AutoHeight)
        {
          return SelectionRules.Moveable | SelectionRules.Visible | SelectionRules.LeftSizeable |
                 SelectionRules.RightSizeable;
        }
        return SelectionRules.AllSizeable | SelectionRules.Moveable | SelectionRules.Visible;
      }
    }

    public override IList SnapLines
    {
      get
      {
        var control = (IPAddressControl)Control;

        var snapLines = base.SnapLines;

        snapLines.Add(new SnapLine(SnapLineType.Baseline, control.Baseline));

        return snapLines;
      }
    }
  }
}