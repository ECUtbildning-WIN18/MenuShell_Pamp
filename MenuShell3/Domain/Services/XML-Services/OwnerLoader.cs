using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    class OwnerLoader
    {
        public IDictionary<long, Owner> LoadOwners()
        {
            var owners = new Dictionary<long, Owner>();

            var doc = XDocument.Load("Owners.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {

                var firstname = element.Attribute("firstName").Value;
                var lastname = element.Attribute("lastName").Value;
                var socSecNr = long.Parse(element.Attribute("socsecnr").Value);

                owners.Add(socSecNr, new Owner(firstname, lastname, socSecNr));
            }

            return owners;
        }
    }
}
