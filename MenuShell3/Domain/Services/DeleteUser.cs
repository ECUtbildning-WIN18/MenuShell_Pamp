using System.Collections.Generic;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services
{
    class DeleteUser
    {
        private readonly Dictionary<string, User> _users;

        public DeleteUser(Dictionary<string, User> users)
        {
            _users = users;
        }

        public string UserDelete(string userName)
        {
            if (_users.ContainsKey(userName))
            {
                _users.Remove(userName);
                return $"\n User {userName} deleted successfully";
            }
            else
            {
                return "Invalid input, try again";               
            }
        }
    }
}
