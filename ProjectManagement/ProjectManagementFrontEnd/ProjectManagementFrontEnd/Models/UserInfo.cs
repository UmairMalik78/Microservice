using System;

namespace ProjectManagementFrontEnd.Models
{
    public class UserInfo
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}