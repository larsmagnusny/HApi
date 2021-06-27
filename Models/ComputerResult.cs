using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.Models
{
    public class ComputerResult
    {
        public int CPUSlots { get; set; }
        public int RAMSlots { get; set; }
        public int SataSlots { get; set; }
        public int PCISlots { get; set; }
        public string Name { get; set; }

        public CPUResult[] Cpus { get; set; }
        public RAMResult[] Rams { get; set; }
        public HDDResult[] Hdds { get; set; }
        public GPUResult[] Gpus { get; set; }
        public NETResult[] Nets { get; set; }
    }

    public class NETResult
    {
        public int Kbs { get; set; }
        public string Name { get; set; }
    }

    public class GPUResult
    {
        public int NumCores { get; set; }
        public int CoreMhz { get; set; }
        public int MB { get; set; }
        public int MemMhz { get; set; }
        public string Name { get; set; }
    }

    public class HDDResult
    {
        public int MB { get; set; }
        public string Name { get; set; }
    }

    public class RAMResult
    {
        public int MHZ { get; set; }
        public int MB { get; set; }
        public string Name { get; set; }
    }

    public class CPUResult
    {
        public int NumCores { get; set; }
        public int MHZ { get; set; }
        public string Name { get; set; }
    }
}
