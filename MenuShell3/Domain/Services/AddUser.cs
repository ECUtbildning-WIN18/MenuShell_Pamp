using System.Collections.Generic;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services
{
    class AddUser
    {
        private readonly Dictionary<string, User> _users;

        public AddUser(Dictionary<string, User> users)
        {
            _users = users;
        }
        public void UserAdd(string userName, string passWord, string role)
        {
            _users.Add(userName, new User(userName, passWord, role));
        }
    }
}
