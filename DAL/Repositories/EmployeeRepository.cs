using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL;

namespace DAL.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IRepository<Employee>
    {
        public EmployeeRepository(IDBUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
