using System;
using System.Collections.Generic;
using System.Threading;
using MenuShell3.Domain.Entities;

namespace MenuShell3.View
{
    class ListUserView
    {
        private readonly Dictionary<string, User> _users;

        public ListUserView(Dictionary<string, User> users)
        {
            _users = users;
        }
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(" # List of users\n");
            foreach (var _user in _users)
            {
                Console.WriteLine($" Username: {_user.Value.Username} - Password: {_user.Value.Password} - Role: {_user.Value.Role}");
            }
            Console.Write("\n\n Press any key to go back");
            Console.ReadKey();
            Thread.Sleep(750);
        }
    }
}
