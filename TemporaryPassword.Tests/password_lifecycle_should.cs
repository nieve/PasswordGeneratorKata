using System;
using NUnit.Framework;

namespace TemporaryPassword.Tests
{
    [TestFixture]
    public class password_lifecycle_should
    {
        readonly PasswordLifecycle Subject = new PasswordLifecycle();
        [Test]
        public void create_password_for_int_id()
        {
            var id = 42;
            var password = Subject.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void create_password_for_guid_id()
        {
            var id = Guid.NewGuid();
            var password = Subject.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void create_password_for_object_id()
        {
            var id = new object();
            var password = Subject.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void invalidate_password_that_exists_for_another_user()
        {
            var anotherId = new object();
            var password = Subject.Create(anotherId);
            var id = new object();

            var isValid = Subject.Validate(id, password);

            Assert.False(isValid);
        }

        [Test]
        public void invalidate_password_when_another_exists_for_the_specified_id()
        {
            var id = new object();
            Subject.Create(id);
            var newInvalidPassword = Subject.Create(id);

            var isValid = Subject.Validate(id, newInvalidPassword);

            Assert.False(isValid);
        }
    }
}
