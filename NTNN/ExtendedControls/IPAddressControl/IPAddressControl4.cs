using FlexFieldControlLib;

using System;
using System.Windows.Forms;

namespace NTNN.ExtendedControls.IPAddressControl
{
    public class IPAddressControl4 : FlexFieldControl
    {

        public IPAddressControl4()
        {
            FieldCount = 4;
            SetMaxLength(3);
            SetSeparatorText(".");
            SetSeparatorText(0, String.Empty);
            SetSeparatorText(FieldCount, String.Empty);
            SetValueFormat(ValueFormat.Decimal);
            SetLeadingZeros(false);
            SetCasing(CharacterCasing.Upper);
            KeyEventArgs e = new KeyEventArgs(Keys.OemSemicolon);
            AddCedeFocusKey(e);
            Size = MinimumSize;
        }
    }
}
