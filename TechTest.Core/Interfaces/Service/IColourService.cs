using System.Collections.Generic;
using TechTest.Entity;

namespace TechTest.Core.Interfaces.Service
{
    public interface IColourService
    {
        Colour GetColour(int id);
        IEnumerable<Colour> GetAllColours();
    }
}
