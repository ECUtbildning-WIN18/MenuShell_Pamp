using System;
using System.Collections.Generic;
using System.Threading;
using MenuShell3.Domain.Entities;

namespace MenuShell3.View
{
    class AdminView
    {
        private readonly Dictionary<string, User> _users;

        public AdminView(Dictionary<string, User> users)
        {
            _users = users;
        }
        private bool done = false;
        public void Display()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. List users");
                Console.WriteLine("3. Delete user");
                Console.WriteLine("4. Log out");
                Console.WriteLine("5. Exit");

                Console.Write("> ");
                var choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        var addUserView = new AddUserView(_users);
                        addUserView.Display();
                        break;
                    case 2:
                        var listUserView = new ListUserView(_users);
                        listUserView.Display();
                        break;
                    case 3:
                        var deleteUserView = new DeleteUserView(_users);
                        deleteUserView.Display();
                        break;
                    case 4:
                        var loginView = new LoginView(_users);
                        loginView.Display();
                        done = true;
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        Thread.Sleep(750);
                        break;
                }

            } while (!done);
        }
    }
}
