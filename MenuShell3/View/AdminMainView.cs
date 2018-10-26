using System;
using System.Collections.Generic;
using System.Threading;
using MenuShell3.Domain.Entities;

namespace MenuShell3.View
{
    class AdminMainView
    {
        private readonly Dictionary<string, User> _users;  //Går att sätta i konstruktorn, om objekt, collection etc.
                                                           //så kan man ändra värden men inte skapa "new"
        public AdminMainView(Dictionary<string, User> users)
        {
            _users = users;
        }
        private bool done = false;
        public void Display()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(" # Admin menu\n");
                Console.WriteLine(" 1. Manage users");
                Console.WriteLine(" 2. Log out");
                Console.WriteLine(" 3. Exit");
                Console.Write(" > ");

                var choice = Console.ReadKey(true);

                if (choice.Key == ConsoleKey.D1)
                {
                    var manageUserView = new ManageUserView(_users);
                    manageUserView.Display();
                }
                else if (choice.Key == ConsoleKey.D2)
                {
                    var loginView = new LoginView(_users);
                    loginView.Display();
                    done = true;
                }
                else if (choice.Key == ConsoleKey.D3)
                {
                    Console.Write("Exiting.");
                    Thread.Sleep(250); Console.Write(".");
                    Thread.Sleep(250); Console.Write(".");
                    Thread.Sleep(250); Console.Write(".");
                    Thread.Sleep(250); Console.Write(".");
                    Thread.Sleep(250); Console.Write(".");
                    Thread.Sleep(250); Console.Write(".");
                    Thread.Sleep(250); Console.Write(".");
                    Thread.Sleep(250); Console.Write(".");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                    Thread.Sleep(750);
                }
            } while (!done);
        }
    }
}
