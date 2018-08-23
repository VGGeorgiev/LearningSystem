using Microsoft.EntityFrameworkCore;
using LearningSystem.Web.Entities;

namespace LearningSystem.Web.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}