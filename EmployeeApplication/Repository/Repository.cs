using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EmployeeApplication.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext dbContext; // protected coz we may need other derviing classes like employeeRepository,authorRepository to access this dbContext

        public Repository(DbContext context)
        {
            dbContext = context;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);

            // throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);

            //  throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {

            return dbContext.Set<TEntity>().Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {

            return dbContext.Set<TEntity>().ToList();
            // throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
           // throw new NotImplementedException();
        }

    }
}