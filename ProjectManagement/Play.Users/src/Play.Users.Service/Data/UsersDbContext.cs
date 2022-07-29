using Microsoft.EntityFrameworkCore;
using Play.Users.Service.Entities;

namespace Play.Users.Service.Data
{
    public class UsersDbContext : DbContext
    {

        public UsersDbContext(DbContextOptions<UsersDbContext> opt) : base(opt) { }

        public DbSet<User> UserTable { get; set; }
    }
}