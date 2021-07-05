namespace HApi.Storage.Entities {
    public class Computer {
        [Key]
        public int Id { get; set; }
        public int MotherboardId { get; set; }
        public string Name { get; set; }
    }
}