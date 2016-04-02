using System;
using System.Collections.Generic;

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
        readonly Dictionary<object, string> _passwords = new Dictionary<object, string>();
        public string Create(int id)
        {
            return NewPassword(id);
        }

        public string Create(Guid id)
        {
            return NewPassword(id);
        }

        public string Create(object id)
        {
            return NewPassword(id);
        }

        public bool Validate(object otherId, string password)
        {
            return _passwords.ContainsKey(otherId);
        }

        private string NewPassword(object id)
        {
            var password = Guid.NewGuid().ToString();
            _passwords.Add(id, password);
            return password;
        }
    }
}
