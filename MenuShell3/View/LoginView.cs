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
    class LoginView
    {
        private readonly Dictionary<string, User> _users;

        public LoginView(Dictionary<string, User> users)
        {
            _users = users;
        }

        public void Display()
        {
            bool notLoggedIn = true;
            var authentication = new Authentication(_users);
            
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
                else if (answer == ConsoleKey.N) //Displays menu again
                {
                    Console.WriteLine("Invalid selection.");
                    Thread.Sleep(500);
                }
            } while (notLoggedIn);

            if ()
            {
                
            }
        }
    }
}
