using System;
using Play.Common;
using Play.Users.Service.Repository;

namespace Play.Users.Service.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}