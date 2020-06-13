using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNN.LogClasses
{
    public class LogPC : LogBase
    {
        public int CPUUserUsage { get; set; }
        public int CPUSystemUsage { get; set; }
        public int CPUUsage { get; set; }
        public int RAMUsage { get; set; }
        public int StorageUsage { get; set; }
    }
}
