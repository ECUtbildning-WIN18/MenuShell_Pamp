using MenuShell3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MenuShell3.Domain.Services.XML_Services
{
    interface IAnimalLoader
    {
        IDictionary<int, Animal> LoadAnimals();
    }
    class AnimalLoader : IAnimalLoader
    {
        public IDictionary<int, Animal> LoadAnimals()
        {
            var animals = new Dictionary<int, Animal>();

            var doc = XDocument.Load("Animals.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {
                var name = element.Attribute("name").Value;
                var idNr = int.Parse(element.Attribute("idnumber").Value);
                var dob = DateTime.Parse(element.Attribute("birthdate").Value);
                var animalType = element.Attribute("animaltype").Value;

                var ownerFName = element.Attribute("firstname").Value;
                var ownerLName = element.Attribute("lastname").Value;
                var ownerSsn = long.Parse(element.Attribute("socsecnr").Value);

                animals.Add(idNr, new Animal(animalType, name, dob, idNr, new Owner(ownerFName, ownerLName, ownerSsn)));
            }

            return animals;
        }
    }
}
