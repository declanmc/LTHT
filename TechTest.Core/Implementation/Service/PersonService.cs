using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Core.Interfaces.Repository;
using TechTest.Core.Interfaces.Service;
using TechTest.Core.Models;
using TechTest.Entity;

namespace TechTest.Core.Implementation.Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Colour> _colourRepository;

        public PersonService(IRepository<Person> personRepository, IRepository<Colour> colourRepository)
        {
            _personRepository = personRepository;
            _colourRepository = colourRepository;
        }

        public PersonModel GetPerson(int id)
        {
            return new PersonModel(_personRepository.Get(id, "Colours"));
        }

        public IEnumerable<PersonModel> GetPeople()
        {
            var personModels = new List<PersonModel>();
            _personRepository.GetAll("Colours").OrderBy(x => x.FirstName).ToList()
                            .ForEach(x => personModels.Add(new PersonModel(x)));
            
            return personModels;
        }

        public PersonModel Update(int id, PersonModel personModel)
        {
            var existingPerson = _personRepository.Get(id, "Colours");
            UpdateFromModel(existingPerson, personModel);
            _personRepository.Update(existingPerson);
            _personRepository.SaveChanges();
            return new PersonModel(existingPerson);
        }

        private void UpdateFromModel(Person existingPerson, PersonModel personModel)
        {
            existingPerson.FirstName = personModel.FirstName;
            existingPerson.LastName = personModel.LastName;
            existingPerson.IsAuthorised = personModel.IsAuthorised;
            existingPerson.IsEnabled = personModel.IsEnabled;
            SetColours(existingPerson, personModel);
        }

        private void SetColours(Person existingPerson, PersonModel personModel)
        {
            var coloursToAdd =
                _colourRepository.GetAll().Where(x => personModel.Colours.Any(c => c.ColourId == x.ColourId)).ToList();
            existingPerson.Colours = coloursToAdd;
        }
    }
}
