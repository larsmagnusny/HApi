using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HApi.DataAccess.Entities {
    public class Computer {
        public Computer()
        {
            CPUs = new HashSet<ComputerCPU>();
            RAMs = new HashSet<ComputerRAM>();
            GPUs = new HashSet<ComputerGPU>();
            HDDs = new HashSet<ComputerHDD>();
            NetworkCards = new HashSet<ComputerNetworkCard>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Motherboard")]
        public int MotherboardId { get; set; }
        public string Name { get; set; }

        public Motherboard Motherboard { get; set; }

        public ICollection<ComputerCPU> CPUs { get; set; }
        public ICollection<ComputerRAM> RAMs { get; set; }
        public ICollection<ComputerGPU> GPUs { get; set; }
        public ICollection<ComputerHDD> HDDs { get; set; }
        public ICollection<ComputerNetworkCard> NetworkCards { get; set; }
    }
}