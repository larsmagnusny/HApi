using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess.Entities
{
    public class ComputerHDD
    {
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [ForeignKey("HDD")]
        public int HDDId { get; set; }

        public Computer Computer { get; set; }
        public HDD HDD { get; set; }
    }
}
