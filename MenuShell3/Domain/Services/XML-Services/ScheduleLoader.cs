using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    interface IScheduleLoader
    {
        IDictionary<DateTime, Schedule> LoadSchedules();
    }
    class ScheduleLoader : IScheduleLoader
    {
        public IDictionary<DateTime, Schedule> LoadSchedules()
        {
            var schedules = new Dictionary<DateTime, Schedule>();

            var doc = XDocument.Load("Schedules.xml");

            var root = doc.Root;

            foreach (var element in root.Elements())
            {
                var appointmentdate = DateTime.Parse(element.Attribute("appointmentdate").Value);
                var problem = element.Attribute("problem").Value;

                var ownerfirstname = element.Attribute("ownerfirstname").Value;
                var ownerlastname = element.Attribute("ownerlastname").Value;
                var ownerssn = long.Parse(element.Attribute("ownerssn").Value);

                var animaltype = element.Attribute("scheduleanimaltype").Value;
                var animalname = element.Attribute("scheduleanimalname").Value;
                var animaldob = DateTime.Parse(element.Attribute("scheduleanimaldob").Value);
                var animalid = int.Parse(element.Attribute("scheduleanimalidnr").Value);

                schedules.Add(appointmentdate, new Schedule(appointmentdate, new Owner(ownerfirstname, ownerlastname, ownerssn),
                    new Animal(animaltype, animalname, animaldob, animalid,
                        new Owner(ownerfirstname, ownerlastname, ownerssn)), problem));
            }

            return schedules;
        }
    }
}
