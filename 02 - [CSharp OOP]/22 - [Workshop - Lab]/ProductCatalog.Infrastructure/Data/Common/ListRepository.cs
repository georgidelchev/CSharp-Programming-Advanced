using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ProductCatalog.Infrastructure.Data.Common
{
    public class ListRepository : IRepository
    {
        private List<object> dbSets;

        public ListRepository()
        {
            this.dbSets = new List<object>();
        }

        public IQueryable<T> All<T>()
            where T : class
        {
            return this.DbSet<T>()
                .AsQueryable();
        }

        public void Add<T>(T entity)
            where T : class
        {
            string keyProperty = this.GetKeyPropertyName<T>();

            PropertyInfo propertyInfo = typeof(T)
                .GetProperty(keyProperty);

            if (propertyInfo.PropertyType == typeof(int))
            {
                propertyInfo.SetValue(entity, this.DbSet<T>().Count + 1);
            }

            this.DbSet<T>()
                .Add(entity);
        }

        public T GetById<T>(object id)
            where T : class
        {
            string keyProperty = this.GetKeyPropertyName<T>();

            T entity = null;

            if (keyProperty != null)
            {
                PropertyInfo propertyInfo = typeof(T)
                    .GetProperty(keyProperty);

                foreach (var item in this.DbSet<T>())
                {
                    if (propertyInfo.GetValue(item).Equals(item))
                    {
                        entity = item;

                        break;
                    }
                }
            }

            if (entity == null)
            {
                throw new KeyNotFoundException("No entity with provided id found!");
            }

            return entity;
        }

        public void Delete<T>(T entity)
            where T : class
        {
            this.DbSet<T>()
                .Remove(entity);
        }

        public void Delete<T>(object id)
            where T : class
        {
            T entity = GetById<T>(id);

            Delete(entity);
        }

        public void Update<T>(T entity)
            where T : class
        {
            string keyProperty = this.GetKeyPropertyName<T>();

            PropertyInfo propertyInfo = typeof(T)
                .GetProperty(keyProperty);

            T item = GetById<T>(propertyInfo.GetValue(entity));

            if (item != null)
            {
                int index = this.DbSet<T>()
                    .IndexOf(item);

                this.DbSet<T>()[index] = entity;
            }
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void Dispose()
        {
            this.dbSets = null;
        }

        private List<T> DbSet<T>()
            where T : class
        {
            object dbSet = this.dbSets
                .FirstOrDefault(s => s.GetType() == typeof(List<T>));

            if (dbSet == null)
            {
                dbSet = new List<T>();

                this.dbSets.Add(dbSet);
            }

            return (List<T>)dbSet;
        }

        private string GetKeyPropertyName<T>()
            where T : class
        {
            string keyProperty = "";

            var properties = typeof(T)
                .GetProperties();

            foreach (var property in properties)
            {
                if (Attribute.IsDefined(property, typeof(KeyAttribute)))
                {
                    keyProperty = property.Name;

                    break;
                }
            }

            if (keyProperty == "")
            {
                keyProperty = properties
                    .Where(p => p.Name.ToUpper() == "ID")
                    .Select(p => p.Name)
                    .FirstOrDefault();
            }

            if (keyProperty == "")
            {
                throw new MemberAccessException("No key property found!");
            }

            return keyProperty;
        }
    }
}
