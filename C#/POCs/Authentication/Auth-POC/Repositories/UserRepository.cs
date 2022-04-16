
using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public static class userRepository
    {
        public static User Get(string username, string Password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Password = "123", Role = "Manager", Username = "Batman" });
            users.Add(new User { Id = 1, Password = "321", Role = "Jarbas", Username = "Jarbas" });

            return users.Find(x => x.Username == username && x.Password == Password);
        }
    }
}