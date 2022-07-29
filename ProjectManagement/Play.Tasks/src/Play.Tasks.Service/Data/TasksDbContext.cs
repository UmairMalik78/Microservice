using Microsoft.EntityFrameworkCore;
using Play.Tasks.Service.Entities;

namespace Play.Tasks.Service.Data
{
    public class TasksDbContext : DbContext
    {

        public TasksDbContext(DbContextOptions<TasksDbContext> opt) : base(opt) { }

        public DbSet<TaskItem> TaskItemTable { get; set; }
        public DbSet<UserInfo> UserInfoTable { get; set; }
    }
}