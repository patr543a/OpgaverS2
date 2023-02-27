using System.Collections;

namespace SqlRocket.Login.Classes
{
    public static class LoginHandler
    {
        private static Hashtable _logins = new()
        {
            { "Test", "1234" }
        };

        public static int? VerifyUser(string username, string password)
        {
            if (!_logins.ContainsKey(username)) return null;

            var login = _logins[username]!.GetHashCode();
            var pass = password.GetHashCode();

            if (login == pass)
                return username.GetHashCode() ^ pass;

            return null;
        }

        public static bool VerifyAccess(string username, string password, int token)
        {
            if (!_logins.ContainsKey(username)) return false;

            var login = _logins[username]!.GetHashCode();
            var pass = password.GetHashCode();

            if (login == pass) 
                return (username.GetHashCode() ^ pass) == token;

            return false;
        }
    }
}
