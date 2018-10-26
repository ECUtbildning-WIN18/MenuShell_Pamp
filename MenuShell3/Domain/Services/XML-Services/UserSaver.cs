using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    class UserSaver
    {
        public void SaveUsers(User user)
        {
            var userList = XDocument.Load("Users.xml");

            var root = userList.Root;

            var userInfo = new XElement("User",
                new XAttribute("username", user.Username),
                new XAttribute("password", user.Password),
                new XAttribute("role", user.Role));

            root.Add(userInfo);

            userList.Save("Users.xml");
        }
    }
}
