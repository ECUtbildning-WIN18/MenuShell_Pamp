using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    class OwnerSaver
    {
        public void SaveOwners(Owner owner)
        {
            var ownerList = XDocument.Load("Owners.xml");

            var root = ownerList.Root;

            var ownerInfo = new XElement("Owner",
                new XAttribute("firstname", owner.FirstName),
                new XAttribute("lastname", owner.LastName),
                new XAttribute("socsecnr", owner.SocSecNr.ToString()));

            root.Add(ownerInfo);

            ownerList.Save("Owners.xml");
        }
    }
}
