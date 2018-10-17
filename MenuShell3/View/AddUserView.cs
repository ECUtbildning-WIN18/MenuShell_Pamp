using System;
using System.Collections.Generic;
using System.Threading;
using MenuShell3.Domain.Entities;
using MenuShell3.Domain.Services;

namespace MenuShell3.View
{
    class AddUserView
    {
        const string Adm = "Administrator";
        const string Rec = "Receptionist";
        const string Vet = "Veterinarian";

        private readonly Dictionary<string, User> _users;

        public AddUserView(Dictionary<string, User> users)
        {
            _users = users;
        }
        private bool done = false;

        public void Display()
        {
            var addUser = new AddUser(_users);

            do
            {
                Console.Clear();
                Console.WriteLine("# Add new user");

                Console.Write("\nUsername: ");
                var userName = Console.ReadLine();
                Console.Write("Password: ");
                var passWord = Console.ReadLine();

                Console.WriteLine("Role: (1) = Receptionist");
                Console.WriteLine("      (2) = Veterinarian");
                Console.WriteLine("      (3) = Administrator");
                Console.Write("> ");

                var roleInt = int.Parse(Console.ReadLine());

                Console.WriteLine("Is this correct (Y)es (N)o");
                var confirm = Console.ReadKey();

                if (confirm.Key == ConsoleKey.Y)
                {
                    if (roleInt == 1 || roleInt == 2 || roleInt == 3)
                    {
                        if (roleInt == 1)
                        {
                            Console.Write(Rec);
                            addUser.UserAdd(userName, passWord, Rec);
                            Console.WriteLine("User added successfully");
                            Thread.Sleep(1000);
                            done = true;
                        }
                        else if (roleInt == 2)
                        {
                            Console.Write(Vet);
                            addUser.UserAdd(userName, passWord, Vet);
                            Console.WriteLine("User added successfully");
                            Thread.Sleep(1000);
                            done = true;
                        }
                        else if (roleInt == 3)
                        {
                            Console.Write(Adm);
                            addUser.UserAdd(userName, passWord, Adm);
                            Console.WriteLine("User added successfully");
                            Thread.Sleep(1000);
                            done = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again");
                        Thread.Sleep(1000);
                    }
                }
            } while (!done);
        }
    }
}
