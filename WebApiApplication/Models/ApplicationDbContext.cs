using Microsoft.EntityFrameworkCore;

namespace WebApiApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=DataBase.db");
    }
}
