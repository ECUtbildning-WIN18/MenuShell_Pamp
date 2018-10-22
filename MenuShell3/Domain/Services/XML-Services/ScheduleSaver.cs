using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MenuShell3.Domain.Entities;

namespace MenuShell3.Domain.Services.XML_Services
{
    interface IScheduleSaver
    {
        void SaveSchedules(Schedule schedule);
    }
    class ScheduleSaver : IScheduleSaver
    {
        public void SaveSchedules(Schedule schedule)
        {
            var scheduleList = XDocument.Load("Schedules.xml");

            var root = scheduleList.Root;

            var scheduleInfo = new XElement("Schedule",
                new XElement("appointmentdate", schedule.AppointmentDate),
                new XElement("problem", schedule.Problem));

            var scheduleOwner = new XElement("Scheduleowner",
                new XElement("ownerfirstname", schedule.Owner.FirstName),
                new XElement("ownerlastname", schedule.Owner.LastName),
                new XElement("ownerssn", schedule.Owner.SocSecNr.ToString()));

            var scheduleAnimal = new XElement("Scheduleanimal",
                new XElement("scheduleanimaltype", schedule.Animal.TypeOfAnimal),
                new XElement("scheduleanimalname", schedule.Animal.Name),
                new XElement("scheduleanimaldob", schedule.Animal.Dob.ToString()),
                new XElement("scheduleanimalidnr", schedule.Animal.IdNr.ToString()),
                new XElement("scheduleanimalownerfname", schedule.Animal.Owner.FirstName),
                new XElement("scheduleanimalownerlname", schedule.Animal.Owner.LastName),
                new XElement("scheduleanimalownerssn", schedule.Animal.Owner.SocSecNr.ToString()));

            scheduleInfo.Add(scheduleOwner);
            scheduleInfo.Add(scheduleAnimal);

            root.Add(scheduleInfo);

            scheduleList.Save("Schedules");
        }
    }
}
