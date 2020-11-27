using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public T GetByName(string name)
        {
            return this.models
                .FirstOrDefault(m => nameof(m).Equals(name));
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models
                .AsReadOnly();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}