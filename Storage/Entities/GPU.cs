namespace HApi.Storage.Entities {
    public class GPU {
        public int Id { get; set; }
        public int NumCores { get; set; }
        public int CoreMhz { get; set; }
        public int MB { get; set; }
        public int MemMhz { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}