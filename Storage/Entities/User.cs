namespace HApi.Storage.Entities {
    [Serializable]
    public class User : IEquatable<User>
    {
        public int UserId{ get; set; }
        public string Username{ get; set; }
        public string Password_SHA256 { get; set; }

        public Profile Profile { get; set; }
    }
}