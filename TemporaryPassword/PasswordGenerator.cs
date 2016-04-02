using System;

namespace TemporaryPassword
{
    public interface IPasswordGenerator
    {
        string Create(int id);
        string Create(Guid id);
        string Create(object id);
    }

    public class PasswordGenerator : IPasswordGenerator
    {
        public string Create(int id)
        {
            return NewPassword();
        }

        public string Create(Guid id)
        {
            return NewPassword();
        }

        public string Create(object id)
        {
            return NewPassword();
        }

        private static string NewPassword()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
