using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Nepository.EfCore.Tests
{
    public sealed class EntityRepositoryTests
    {
        #region Constructor

        [Fact]
        public void Can_Construct()
        {
            var builder = new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase(nameof(EntityRepositoryTests));
            var context = new TestContext(builder.Options);
            new EntityRepository<User>(context);
        }

        [Fact]
        public void Construct_With_Null_Context_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new EntityRepository<User>(null));
        }

        #endregion Constructor

        #region Create

        [Fact]
        public void Can_Create()
        {
            var user = new User
            {
                Username = "testuser",
                Email = "test@test.com"
            };

            var repo = new EntityRepository<User>(GetContext());
            repo.Create(user);

            var loadedUser = repo.Get(user.Id);
            Assert.Equal(user.Id, loadedUser.Id);
            Assert.Equal(user.Username, loadedUser.Username);
            Assert.Equal(user.Email, loadedUser.Email);
        }

        #endregion Create

        private TestContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            optionsBuilder.UseInMemoryDatabase(nameof(EntityRepositoryTests));
            return new TestContext(optionsBuilder.Options);
        }
    }
}