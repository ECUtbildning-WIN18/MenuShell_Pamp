using System;
using System.Collections.Generic;
using System.Threading;
using MenuShell3.Domain.Entities;

namespace MenuShell3.View
{
    class DeleteUserView
    {
        private readonly Dictionary<string, User> _users;

        public DeleteUserView(Dictionary<string, User> users)
        {
            _users = users;
        }
        public void Display()
        {
            bool done = false;
            do
            {
                Console.Clear();
                Console.WriteLine("# Delete existing user");
                Console.Write("\n\nUsername of user you want to delete:\n> ");
                var delUser = Console.ReadLine();
                Console.WriteLine("\nAre you sure (Y)es (N)o");
                var confirm = Console.ReadKey(true);
                if (confirm.Key == ConsoleKey.Y)
                {
                    if (_users.ContainsKey(delUser))
                    {
                        _users.Remove(delUser);
                        Console.WriteLine("User deleted successfully");
                        Thread.Sleep(1000);
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("There's no user with that username");
                        done = true;
                        Thread.Sleep(750);
                    }
                }
            } while (!done);
        }
    }
}
