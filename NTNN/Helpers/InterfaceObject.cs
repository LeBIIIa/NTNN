using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNN.Helpers
{
    public class InterfaceObject
    {
        public string Desc { get; set; }
        public uint In { get; set; }
        public uint Out { get; set; }

        public void Deconstruct(out KeyValuePair<string, string>[] pairs)
        {
            pairs = new KeyValuePair<string, string>[5];
            pairs[0] = new KeyValuePair<string, string>("Desc", Desc);
            pairs[1] = new KeyValuePair<string, string>("In", In.ToString());
            pairs[2] = new KeyValuePair<string, string>("Out", Out.ToString());
        }
    }
}
