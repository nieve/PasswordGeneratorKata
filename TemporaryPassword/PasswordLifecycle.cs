using System;
using System.Collections.Generic;

namespace TemporaryPassword
{
    public class PasswordLifecycle
    {
        static readonly Dictionary<object, string> PasswordById = new Dictionary<object, string>();
        readonly Func<string> _generatePassword;

        public PasswordLifecycle(Func<string> generatePassword = null)
        {
            _generatePassword = generatePassword ?? (() => Guid.NewGuid().ToString());
        }

        public string Create(object id)
        {
            return NewPassword(id);
        }

        public bool Validate(object id, string password)
        {
            return IdHasPassword(id) && PasswordById[id] == password;
        }

        private string NewPassword(object id)
        {
            var password = _generatePassword();
            if (PasswordTaken(password)) return NewPassword(id);

            if (IdHasPassword(id)) return password;

            PasswordById.Add(id, password);
            return password;
        }

        private static bool PasswordTaken(string password)
        {
            return PasswordById.ContainsValue(password);
        }

        private static bool IdHasPassword(object id)
        {
            return PasswordById.ContainsKey(id);
        }
    }
}
