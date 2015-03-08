using System.Collections.Generic;
using System.Linq;
using TechTest.Core.Implementation.Service;
using TechTest.Entity;

namespace TechTest.Core.Models
{
    public class PersonModel 
    {
        public PersonModel()
        {   
        }

        public PersonModel(Person person)
        {
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
            IsAuthorised = person.IsAuthorised;
            IsValid = person.IsValid;
            IsEnabled = person.IsEnabled;
            Colours = person.Colours.ToList().Select(x => new ColourModel(x)).ToList();
        }
    
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }

        public List<ColourModel> Colours { get; set; }
    }
}