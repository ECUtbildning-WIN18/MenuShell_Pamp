using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MenuShell3.Domain.Entities;
using MenuShell3.Domain.Services;

namespace MenuShell3.View
{
    class SearchUserView
    {
        private readonly Dictionary<string, User> _users;

        public SearchUserView(Dictionary<string, User> users)
        {
            _users = users;
        }

        public void Display()
        {
            var searchUser = new SearchUser(_users);
            var done = false;
            do
            {
                Console.Clear();
                Console.WriteLine(" # Search User");
                Console.WriteLine("\n Search by username:");
                Console.Write("\n > ");

                var searchName = Console.ReadLine();
                var searchHits = searchUser.UserSearch(searchName);
                var deleteUser = new DeleteUser(_users);

                if (searchHits.Any())
                {
                    Console.Clear();
                    Console.WriteLine($" # Users matching your search: {searchName}\n");
                    foreach (var searchHit in searchHits)
                    {
                        Console.WriteLine($" Username: {searchHit.Username}");
                    }

                    Console.Write($"\n (D)elete (V)iew (E)xit");
                    var choice = Console.ReadKey(true);

                    if (choice.Key == ConsoleKey.D)
                    {
                        Console.Clear();
                        foreach (var searchHit in searchHits)
                        {
                            Console.WriteLine($" Username: {searchHit.Username}");
                        }
                        Console.Write($"\n Delete> ");

                        string userForDeletion = Console.ReadLine();
                        deleteUser.UserDelete(userForDeletion);

                        Console.Write(deleteUser.UserDelete(userForDeletion));
                        Thread.Sleep(2000);
                        done = true;
                    }
                    else if (choice.Key == ConsoleKey.V)
                    {
                        Console.Clear();
                        foreach (var searchHit in searchHits)
                        {
                            Console.WriteLine($" Username: {searchHit.Username}");
                        }
                        Console.Write($"\n View details for user> ");

                        var userForViewing = Console.ReadLine();
                        if (_users.ContainsKey(userForViewing))
                        {
                            Console.WriteLine($" User name:     {_users[userForViewing].Username}");
                            Console.WriteLine($" User password: {_users[userForViewing].Password}");
                            Console.WriteLine($" User role:     {_users[userForViewing].Role}");
                            Console.Write("\n Delete user (Y)es (N)o");

                            if (Console.ReadKey().Key==ConsoleKey.Y)
                            {
                                Console.Write($" Are you certain?  (Y)es (N)o");
                                var confirm = Console.ReadKey(true);
                                if (confirm.Key==ConsoleKey.Y)
                                {
                                    deleteUser.UserDelete(userForViewing);
                                    Console.Write(deleteUser.UserDelete(userForViewing));
                                    Thread.Sleep(2000);
                                    done = true;
                                }
                            }
                            else
                            {
                                done = true;
                            }
                        }
                        else
                        {
                            Console.Write("Invalid input, press any key");
                            Console.ReadKey();
                            done = true;
                        }
                    }
                    else
                    {
                        done = true;
                    }
                }
                else
                {
                    Console.WriteLine($" No users found matching the search term {searchName}.");
                    Thread.Sleep(2000);
                }

            } while (!done);
        }
    }
}
