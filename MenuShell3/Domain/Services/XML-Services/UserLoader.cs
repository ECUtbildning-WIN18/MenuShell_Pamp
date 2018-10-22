using System.Collections.Generic;
using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services
{
    interface IUserLoader
    {
        Dictionary<string, User> LoadUsers();
    }

    class UserLoader : IUserLoader
    {
        public Dictionary<string, User> LoadUsers()
        {
            var users = new Dictionary<string, User>();

            var doc = XDocument.Load("Users.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {
                var username = element.Attribute("username").Value;
                var password = element.Attribute("password").Value;
                var role = element.Attribute("role").Value;

                users.Add(username, new User(username, password, role));
            }

            return users;
        }
    }
}
