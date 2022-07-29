using System;
using Play.Common;

namespace Play.Tasks.Service.Entities
{
    public class UserInfo : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}