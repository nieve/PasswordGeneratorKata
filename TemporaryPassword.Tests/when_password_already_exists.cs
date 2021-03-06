using NUnit.Framework;

namespace TemporaryPassword.Tests
{
    public class when_password_already_exists
    {
        private static int _count = 0;
        private static readonly string SomePassword = "some password";
        private static readonly string NewPassword = "new password";

        readonly PasswordLifecycle Subject = new PasswordLifecycle(FakePasswordGenerator);
        private static string FakePasswordGenerator()
        {
            return _count++ > 1 ? NewPassword : SomePassword;
        }

        [Test]
        public void then_it_should_use_another_password()
        {
            var id = new object();
            var password = Subject.Create(id);

            var anotherId = new object();
            var anotherPassword = Subject.Create(anotherId);

            Assert.AreNotEqual(password, anotherPassword);
        }
    }
}