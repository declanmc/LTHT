using System.Collections.Generic;
using TechTest.Core.Models;


namespace TechTest.Core.Interfaces.Service
{
    public interface IPersonService
    {
        PersonModel GetPerson(int id);
        IEnumerable<PersonModel> GetPeople();
        PersonModel Update(int id, PersonModel personModel);
    }
}
