using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Core.Interfaces.Repository;
using TechTest.Core.Interfaces.Service;
using TechTest.Entity;

namespace TechTest.Core.Implementation.Service
{
    public class ColourService : IColourService
    {
        private readonly IRepository<Colour> _repository;

        public ColourService(IRepository<Colour> repository)
        {
            _repository = repository;
        }

        public Colour GetColour(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Colour> GetAllColours()
        {
            return _repository.GetAll();
        }
    }
}
