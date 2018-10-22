using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShell3.Domain.Entities
{
    class Journal
    {
        public Owner Owner { get; }
        public Animal Animal { get; }
        public string Ailment { get; set; }

        public Journal(Owner owner, Animal animal, string ailment)
        {
            Owner = owner;
            Animal = animal;
            Ailment = ailment;
        }
        public override string ToString()
        {
            return $"{Owner.FirstName} {Owner.LastName} {Animal.Name} {Animal.IdNr} {Ailment}";
        }
    }
}
