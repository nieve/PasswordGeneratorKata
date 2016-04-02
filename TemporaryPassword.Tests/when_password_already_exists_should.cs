using System;
using NUnit.Framework;

namespace TemporaryPassword.Tests
{
    public class when_password_already_exists_should
    {
        private int _count = 0;
        private static readonly string SomePassword = "some password";
        private static readonly string NewPassword = "new password";

        [SetUp]
        public void SetUp()
        {
            TestPassword.OverridePasswordGeneration(FakePasswordGenerator);
        }

        private string FakePasswordGenerator()
        {
            return _count++ > 1 ? NewPassword : SomePassword;
        }

        [Test]
        public void use_another_password()
        {
            var id = new object();
            var password = Password.Create(id);

            var anotherId = new object();
            var anotherPassword = Password.Create(anotherId);

            Assert.AreNotEqual(password, anotherPassword);
        }

        [TearDown]
        public void TearDown()
        {
            TestPassword.OverridePasswordGeneration(() => Guid.NewGuid().ToString());
        }
    }

    public class TestPassword : Password
    {
        public static void OverridePasswordGeneration(Func<string> generatePassword)
        {
            _generatePassword = generatePassword;
        }
    }
}