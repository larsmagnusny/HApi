namespace HApi.Storage.Entities {
    public class NetworkCard {
        [Key]
        public int Id { get; set; }
        public int Kbs { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}