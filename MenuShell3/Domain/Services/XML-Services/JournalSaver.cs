using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    interface IJournalSaver
    {
        void SaveJournals(Journal journal);
    }
    class JournalSaver : IJournalSaver
    {
        public void SaveJournals(Journal journal)
        {
            var journalList = XDocument.Load("Journals.xml");

            var root = journalList.Root;

            var journalInfo = new XElement("Journal",
                new XElement("ailment", journal.Ailment));

            var journalOwner = new XElement("Owner",
                new XElement("firstname", journal.Owner.FirstName),
                new XElement("lastname", journal.Owner.LastName),
                new XElement("socsecnr", journal.Owner.SocSecNr));

            var journalAnimal = new XElement("Animal",
                new XElement("animaltype", journal.Animal.TypeOfAnimal),
                new XElement("name", journal.Animal.Name),
                new XElement("dob", journal.Animal.Dob),
                new XElement("idnumber", journal.Animal.IdNr),
                new XElement("animalownerfirstname", journal.Animal.Owner.FirstName),
                new XElement("animalownerlastname", journal.Animal.Owner.LastName),
                new XElement("animalownersss", journal.Animal.Owner.SocSecNr));

            journalInfo.Add(journalOwner);
            journalInfo.Add(journalAnimal);

            root.Add(journalInfo);

            journalList.Save("Journals.xml");
        }
    }
}
