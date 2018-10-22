using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    interface IJournalLoader
    {
        IDictionary<int, Journal> LoadJournals();
    }
    class JournalLoader : IJournalLoader  
    {
        public IDictionary<int, Journal> LoadJournals()
        {
            var journals = new Dictionary<int, Journal>();

            var doc = XDocument.Load("Journals.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {
                var ailment = element.Attribute("Ailment").Value;

                var firstname = element.Attribute("firstname").Value;
                var lastname = element.Attribute("lastname").Value;
                var socsecnr = long.Parse(element.Attribute("socsecnr").Value);

                var animaltype = element.Attribute("animaltype").Value;
                var animalname = element.Attribute("name").Value;
                var dob = DateTime.Parse(element.Attribute("dob").Value);
                var idnr = int.Parse(element.Attribute("idnumber").Value);
                //var animalownerFirstname = element.Attribute("AnimalownerFirstname").Value;
                //var animalownerLastname = element.Attribute("AnimalownerLastname").Value;
                //var animalownerssn = long.Parse(element.Attribute("AnimalownerSSN").Value);

                journals.Add(idnr, new Journal(new Owner(firstname, lastname, socsecnr),
                    new Animal(animaltype, animalname, dob, idnr,
                        new Owner(firstname, lastname, socsecnr)), ailment));
            }

            return journals;
        }
    }
}
