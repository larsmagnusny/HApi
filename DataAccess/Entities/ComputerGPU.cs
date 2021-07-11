using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess.Entities
{
    public class ComputerGPU
    {
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [ForeignKey("GPU")]
        public int GPUId { get; set; }

        public Computer Computer { get; set; }
        public GPU GPU { get; set; }
    }
}
