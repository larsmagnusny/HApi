using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HApi.DataAccess.Entities {
    public class Computer {
        public Computer()
        {
            CPUs = new HashSet<CPU>();
            RAMs = new HashSet<RAM>();
            GPUs = new HashSet<GPU>();
            HDDs = new HashSet<HDD>();
            NetworkCards = new HashSet<NetworkCard>();
        }

        [Key]
        public int Id { get; set; }
        public int MotherboardId { get; set; }
        public string Name { get; set; }

        public virtual Motherboard Motherboard { get; set; }

        public virtual ICollection<CPU> CPUs { get; set; }
        public virtual ICollection<RAM> RAMs { get; set; }
        public virtual ICollection<GPU> GPUs { get; set; }
        public virtual ICollection<HDD> HDDs { get; set; }
        public virtual ICollection<NetworkCard> NetworkCards { get; set; }
    }
}