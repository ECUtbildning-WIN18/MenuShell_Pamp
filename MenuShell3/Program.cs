using MenuShell3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MenuShell3.View;

namespace MenuShell3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Adm = "Administrator";
            const string Rec = "Receptionist";
            const string Vet = "Veterinarian";

            bool notLoggedIn = true;

            var users = new Dictionary<string, User>
            {
                {"admin", new User("admin", "secret",Adm)},
                {"johndoe", new User("johndoe", "secret",Rec)},
                {"janedoe", new User("janedoe", "secret",Vet)},
                {"jimdoe", new User("jimdoe", "secret", Adm)}
            };

            var loginView = new LoginView(users);
            loginView.Display();

            //if (user.Role == Adm)
            //{
            //    // Inloggad admin
            //    Console.Clear();
            //    Console.WriteLine("1 Add user");
            //    Console.WriteLine("2. List userDictionary");
            //    Console.WriteLine("3. Remove user");
            //    Console.WriteLine("4. Exit");
            //}
            //if (user.Role == Rec)
            //{
            //    //Receptionist
            //    Console.WriteLine("1. Register customer");
            //    Console.WriteLine("2. Make appointment");
            //    Console.WriteLine("3. Exit");
            //}
            //if (user.Role == Vet)
            //{
            //    //Veterinarian
            //    Console.WriteLine("1. List appointments");
            //    Console.WriteLine("2. Exit");
            //}

            //var menuSelection = Console.ReadKey(true).Key;

            //if (menuSelection == ConsoleKey.D1)
            //{
            //    //Lägg till användare
            //}
        }
    }
}
