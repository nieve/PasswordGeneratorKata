using System;
using NUnit.Framework;

namespace TemporaryPassword.Tests
{
    [TestFixture]
    public class password_generator_should
    {
        [Test]
        public void create_password_for_int_id()
        {
            var id = 42;
            var password = Password.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void create_password_for_guid_id()
        {
            var id = Guid.NewGuid();
            var password = Password.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void create_password_for_object_id()
        {
            var id = new object();
            var password = Password.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void invalidate_password_that_exists_for_another_user()
        {
            var anotherId = new object();
            var password = Password.Create(anotherId);
            var id = new object();

            var isValid = Password.Validate(id, password);

            Assert.False(isValid);
        }
    }
}
