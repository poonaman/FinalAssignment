using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Repository
{
   public interface IUnitOfWork :IDisposable
    {
        IEmployeeRepository Employees { get; }
        IStudioRepository Studios { get; }
        ITokenRepository Tokens { get; }
        
        int complete();

    }
}
