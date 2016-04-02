using System;
using System.Collections.Generic;

namespace TemporaryPassword
{
    public class Password
    {
        readonly static Dictionary<object, string> _passwords = new Dictionary<object, string>();
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
            var password = Guid.NewGuid().ToString();
            _passwords.Add(id, password);
            return password;
        }
    }
}
