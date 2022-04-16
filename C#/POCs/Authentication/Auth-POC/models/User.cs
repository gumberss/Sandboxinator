namespace ApiAuth.Models
{
    public record User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String? Role { get; set; }
    }
}