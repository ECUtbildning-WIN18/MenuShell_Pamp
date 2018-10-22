using System;
using System.Collections.Generic;
using System.Threading;
using MenuShell3.Domain.Entities;

namespace MenuShell3.View
{
    class ManageUserView
    {
        private readonly Dictionary<string, User> _users;

        public ManageUserView(Dictionary<string, User> users)
        {
            _users = users;
        }

        public void Display()
        {
            var done = false;
            do
            {
                Console.Clear();
                Console.WriteLine(" # User management menu");
                Console.WriteLine("\n 1. Search user");
                Console.WriteLine(" 2. Add user");
                Console.WriteLine(" 3. List users");
                //Console.WriteLine(" 4. Delete user");
                Console.WriteLine(" 5. Return to main menu");
                Console.Write(" > ");

                var choice = Console.ReadKey(true);

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        var searchUserView = new SearchUserView(_users);
                        searchUserView.Display();
                        break;
                    case ConsoleKey.D2:
                        var addUserView = new AddUserView(_users);
                        addUserView.Display();
                        break;
                    case ConsoleKey.D3:
                        var listUserView = new ListUserView(_users);
                        listUserView.Display();
                        break;
                    //case ConsoleKey.D4:
                    //    var deleteUserView = new DeleteUserView(_users);
                    //    deleteUserView.Display();
                    //    break;
                    case ConsoleKey.D5:
                        Console.Write("Exiting.");
                        Thread.Sleep(250); Console.Write(".");
                        Thread.Sleep(250); Console.Write(".");
                        Thread.Sleep(250); Console.Write(".");
                        Thread.Sleep(250); Console.Write(".");
                        Thread.Sleep(250); Console.Write(".");
                        Thread.Sleep(250); Console.Write(".");
                        Thread.Sleep(250); Console.Write(".");
                        Thread.Sleep(250); Console.Write(".");

                        done = true;
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
