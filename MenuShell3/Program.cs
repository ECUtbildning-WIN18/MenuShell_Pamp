using MenuShell3.Domain.Entities;
using System.Collections.Generic;
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

            var users = new Dictionary<string, User>
            {
                {"admin", new User("admin", "secret",Adm)},
                {"johndoe", new User("johndoe", "secret",Rec)},
                {"janedoe", new User("janedoe", "secret",Vet)},
                {"jimdoe", new User("jimdoe", "secret", Adm)}
            };

            var loginView = new LoginView(users);
            loginView.Display();
        }
    }
}
