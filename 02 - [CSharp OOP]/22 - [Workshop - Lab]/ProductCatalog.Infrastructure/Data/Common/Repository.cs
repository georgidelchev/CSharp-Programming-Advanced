using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        public Repository(ApplicationDbContext context)
        {
            this.DbContext = context;
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet<T>()
            where T : class
        {
            return DbContext.Set<T>();
        }

        public void Dispose()
        {
            this.DbContext
                .Dispose();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return this.DbSet<T>()
                .AsQueryable();
        }

        public void Add<T>(T entity) where T : class
        {
            this.DbSet<T>()
                .Add(entity);
        }

        public T GetById<T>(object id) where T : class
        {
            return this.DbSet<T>()
                .Find(id);
        }

        public void Update<T>(T entity) where T : class
        {
            this.DbSet<T>()
                .Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
        }

        public void Delete<T>(object id) where T : class
        {
        }

        public int SaveChanges()
        {
            return this.DbContext
                .SaveChanges();
        }
    }
}
