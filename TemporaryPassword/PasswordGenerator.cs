using System;

namespace TemporaryPassword
{
    public interface IPasswordGenerator
    {
        string Create(int id);
        string Create(Guid id);
        string Create(object id);
        bool Validate(object otherId, string password);
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

        public bool Validate(object otherId, string password)
        {
            throw new NotImplementedException();
        }

        private static string NewPassword()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
