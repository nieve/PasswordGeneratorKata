using System;
using NUnit.Framework;

namespace TemporaryPassword.Tests
{
    [TestFixture]
    public class password_generator_should
    {
        IPasswordGenerator subject = new PasswordGenerator();

        [Test]
        public void create_password_for_int_id()
        {
            var id = 42;
            var password = subject.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void create_password_for_guid_id()
        {
            var id = Guid.NewGuid();
            var password = subject.Create(id);
            Assert.NotNull(password);
        }

        [Test]
        public void create_password_for_object_id()
        {
            var id = new object();
            var password = subject.Create(id);
            Assert.NotNull(password);
        }
    }
}
