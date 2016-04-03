using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemporaryPassword
{
    public class PasswordLifecycle
    {
        static readonly Dictionary<object, string> PasswordById = new Dictionary<object, string>();
        readonly Func<string> _generatePassword;
        private readonly int _passwordLifetime;

        public int PasswordLifetime => _passwordLifetime;

        public PasswordLifecycle(Func<string> generatePassword = null, int passwordLifetime = 30000)
        {
            _generatePassword = generatePassword ?? (() => Guid.NewGuid().ToString());
            _passwordLifetime = passwordLifetime;
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
            SchedulePasswordExpiryFor(id);

            return password;
        }

        private async Task SchedulePasswordExpiryFor(object id)
        {
            await Task.Delay(_passwordLifetime)
                .ContinueWith(t => { if (PasswordById.ContainsKey(id)) PasswordById.Remove(id); })
                .ConfigureAwait(false);
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
