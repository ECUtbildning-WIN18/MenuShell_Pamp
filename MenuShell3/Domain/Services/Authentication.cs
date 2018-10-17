using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services
{
    class Authentication
    {
        private readonly Dictionary<string, User> _users;

        public Authentication(Dictionary<string, User> users)
        {
            _users = users;
        }

        public User Authenticate(string userName, string passWord)
        {
            if (_users.ContainsKey(userName) && _users[userName].Password == passWord)
            {
                return _users[userName];
            }
            else
            {
                return null;
            }
        }
    }
}
