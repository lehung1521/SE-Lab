using System;
using System.Xml.Linq;

namespace WebUI
{
    // Simple user service to validate credentials. Replace with real implementation as needed.
    public class UserService
    {
        public bool CheckLogin(string username, string password)
        {
            // Basic placeholder logic: treat non-empty username/password as success for now
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            // Example: accept 'admin' / 'password'. Replace with real auth logic later.
            return username == "admin" && password == "password";
        }
    }
}