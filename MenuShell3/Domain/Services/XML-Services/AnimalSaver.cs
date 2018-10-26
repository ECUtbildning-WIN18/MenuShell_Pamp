using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    class AnimalSaver
    {
        public void SaveAnimals(Animal animal)
        {
            var animalList = XDocument.Load("Animals.xml");

            var root = animalList.Root;

            var animalInfo = new XElement("Animal",
                new XElement("name", animal.Name),
                new XElement("idnumber", animal.IdNr.ToString()),
                new XElement("animaltype", animal.TypeOfAnimal),
                new XElement("birthdate", animal.Dob.ToString()));

            var animalOwner =
                new XElement("Owner",
                    new XElement("firstname", animal.Owner.FirstName),
                    new XElement("lastname", animal.Owner.LastName),
                    new XElement("socsecnr", animal.Owner.SocSecNr));

            animalInfo.Add(animalOwner);

            root.Add(animalInfo);

            animalList.Save("Animals.xml");
        }
    }
}
