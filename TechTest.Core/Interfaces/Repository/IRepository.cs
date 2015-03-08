using System.Collections.Generic;

namespace TechTest.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id, string children = null);

        IEnumerable<T> GetAll(string children = null);

        void Update(T entity);

        void SaveChanges();
    }
}
