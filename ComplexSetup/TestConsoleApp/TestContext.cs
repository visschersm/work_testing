using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestConsoleApp
{
    public class TestContext : DbContext, IContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
