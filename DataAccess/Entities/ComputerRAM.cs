using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HApi.DataAccess.Entities
{
    public class ComputerRAM
    {
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [ForeignKey("RAM")]
        public int RAMId { get; set; }

        public Computer Computer { get; set; }
        public RAM RAM { get; set; }
    }
}
