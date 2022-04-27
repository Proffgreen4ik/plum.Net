using Microsoft.EntityFrameworkCore;
using plumcourse.Data.Models;
namespace plumcourse.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Course> Course{ get; set; }
        public DbSet<User> User { get; set; }
    }
}
