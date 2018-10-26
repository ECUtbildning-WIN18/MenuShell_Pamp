using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShell3.Domain.Entities
{
    class User
    {
        public string Username { get; }
        public string Password { get; }
        public string Role { get; }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
