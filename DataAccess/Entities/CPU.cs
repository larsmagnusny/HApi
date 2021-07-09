using System.ComponentModel.DataAnnotations;

namespace HApi.DataAccess.Entities {
    public class CPU {
        [Key]
        public int Id { get; set; }
        public int NumCores { get; set; }
        public int MHZ { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}