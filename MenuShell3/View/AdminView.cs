using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MenuShell3.Domain.Entities;
using MenuShell3.Domain.Services;

namespace MenuShell3.View
{
    class AdminView
    {


        private readonly Dictionary<string, User> _users;
        public AdminView(Dictionary<string, User> users)
        {
            _users = users;
        }

        bool notLoggedIn = true;

        public void Display()
        {
            do
            {
                Console.Clear();
                Console.Write("Username: ");
                var userName = Console.ReadLine();

                Console.Write("Password: ");
                var passWord = Console.ReadLine();

                Console.WriteLine("Is this correct? (Y)es (N)o");

                var answer = Console.ReadKey(true).Key;

                if (answer == ConsoleKey.Y)
                {
                    var authentication = new Authentication(_users);

                    if (authentication.Authenticate(userName, passWord) != null) //Valid user
                    {
                        notLoggedIn = false;
                    }
                    else //Invalid user
                    {
                        Console.WriteLine("Invalid username and/or password, try again.");
                        Thread.Sleep(500);
                    }
                }
                else if (answer == ConsoleKey.N) //Ritar menyn igen 
                {
                    Console.WriteLine("Invalid selection.");
                    Thread.Sleep(500);
                }

            } while (notLoggedIn);

        }
    }
}
