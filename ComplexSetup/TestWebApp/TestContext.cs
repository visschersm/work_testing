using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp
{
    public class TestContext : DbContext, IContext
    {
        public DbSet<User> Users { get; set; }

        public TestContext()
            : base()
        {

        }

        public TestContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Database=TestDatabase;Username=postgres;Password=mysecretpassword");
        }
    }
}
