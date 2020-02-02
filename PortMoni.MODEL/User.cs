using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PortMoni.MODEL
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int WalletId { get; set; }

        public User(string fullName, string email, string userName, string password)
        {
            FullName = fullName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
