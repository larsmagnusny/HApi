using System.ComponentModel.DataAnnotations;

namespace HApi.DataAccess.Entities { 
    public class HDD {
        [Key]
        public int Id { get; set; }
        public int MB { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}