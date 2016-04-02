using System;
using System.Collections.Generic;

namespace TemporaryPassword
{
    public class Password
    {
        private static readonly Dictionary<object, string> _passwords = new Dictionary<object, string>();
        protected static Func<string> _generatePassword = () => Guid.NewGuid().ToString();
        public static string Create(object id)
        {
            return NewPassword(id);
        }

        public static bool Validate(object otherId, string password)
        {
            return _passwords.ContainsKey(otherId);
        }

        private static string NewPassword(object id)
        {
            var password = _generatePassword();
            if (_passwords.ContainsValue(password)) return NewPassword(id);
            _passwords.Add(id, password);
            return password;
        }
    }
}
