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
    }
}
