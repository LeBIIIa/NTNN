using NTNN.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNN.LogClasses
{
    public class LogRouter : LogBase
    {
        public int CPUUsage { get; set; }
        public int StorageUsage { get; set; }

        public List<InterfaceObject> Interfaces { get; set; }
    }
}
