namespace HApi.Storage.Entities {
    [Serializable]
    public class Profile : IEquatable<User> {
        public int UserId{ get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}