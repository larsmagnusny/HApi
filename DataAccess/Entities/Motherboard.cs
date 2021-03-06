using System.ComponentModel.DataAnnotations;

namespace HApi.DataAccess.Entities {
    public class Motherboard {
        [Key]
        public int Id { get; set; }
        public int CPUSlots { get; set; }
        public int RAMSlots { get; set; }
        public int SataSlots { get; set; }
        public int PCISlots { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}