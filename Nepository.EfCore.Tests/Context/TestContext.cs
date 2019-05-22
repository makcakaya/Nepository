using Microsoft.EntityFrameworkCore;

namespace Nepository.EfCore.Tests
{
    public sealed class TestContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
    }
}