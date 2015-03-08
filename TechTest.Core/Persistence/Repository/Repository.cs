using System.Collections.Generic;
using System.Linq;
using TechTest.Core.Interfaces.Repository;
using TechTest.Entity;
using EntityState = System.Data.Entity.EntityState;

namespace TechTest.Core.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TechTestEntities _db;
        
        public Repository(TechTestEntities db)
        {
            db.Configuration.ProxyCreationEnabled = false;
            _db = db;
        }

        public T Get(int id, string children = null)
        {
            var person = _db.Set<T>().Find(id);
            if(!string.IsNullOrEmpty(children))
                _db.Entry(person).Collection(children).Load();
            return person;
        }

        public IEnumerable<T> GetAll(string children = null)
        {
            return string.IsNullOrEmpty(children) 
                ? _db.Set<T>().ToList()
                : _db.Set<T>().Include(children).ToList();
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}