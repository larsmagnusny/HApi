using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess.Entities
{
    public class ComputerCPU
    {
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        
        [ForeignKey("CPU")]
        public int CPUId { get; set; }
        
        public Computer Computer { get; set; }
        public CPU CPU { get; set; }
    }
}
