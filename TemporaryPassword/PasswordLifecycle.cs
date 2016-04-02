using System;
using System.Collections.Generic;

namespace TemporaryPassword
{
    public class PasswordLifecycle
    {
        static readonly Dictionary<object, string> _passwords = new Dictionary<object, string>();
        readonly Func<string> _generatePassword;

        public PasswordLifecycle(Func<string> generatePassword = null)
        {
            _generatePassword = generatePassword ?? (() => Guid.NewGuid().ToString());
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
            var password = _generatePassword();
            if (_passwords.ContainsValue(password)) return NewPassword(id);
            _passwords.Add(id, password);
            return password;
        }
    }
}
