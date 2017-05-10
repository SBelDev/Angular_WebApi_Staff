using DAL.Repositories;
using DAL;

namespace Core.Services
{
    public class EmployeeService : BaseService<Employee>, IService<Employee>
    {
        public EmployeeService(IRepository<Employee> genericRepository) : base(genericRepository)
        {
        }
    }
}
