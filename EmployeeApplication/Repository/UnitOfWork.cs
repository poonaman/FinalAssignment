using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeApplication.Models;

namespace EmployeeApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context Context;

        public UnitOfWork(Context context)
        {
            Context = context;
            Employees = new EmployeeRepository(Context);
            Studios = new StudioRepository(Context);
            Tokens = new TokenRepository(Context);
        }
        public ITokenRepository Tokens { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IStudioRepository Studios { get; private set; }

        //  public IEmployeeRepository Employee => throw new NotImplementedException();

        public int complete()
        {
          return  Context.SaveChanges();
           // throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
          //  throw new NotImplementedException();
        }
    }
}