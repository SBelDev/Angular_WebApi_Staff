using Core.Services;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.ModelVM;

namespace Web.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private IService<Employee> employeeService;
        private IService<JobTitle> jobTitleService;

        public EmployeesController(IService<Employee> employeeService, IService<JobTitle> jobTitleService)
        {
            this.employeeService = employeeService;
            this.jobTitleService = jobTitleService;
        }

        [ActionName("GetEmployees")]
        public IEnumerable<EmployeeVM> GetEmployees()
        {
            List<EmployeeVM> employeeVMs = new List<EmployeeVM>();

            foreach (var emp in employeeService.GetAll())
            {
                employeeVMs.Add(new EmployeeVM()
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    EmploymentDate = emp.EmploymentDate,
                    Rate = emp.Rate,
                    JobTitleName = emp.JobTitle.Name
                });
            }
            return employeeVMs;
        }


        [ActionName("GetEmployeesJobTitles")]
        public List<JobTitleVM> GetEmployeesJobTitles()
        {
            List<JobTitleVM> jobTitles = new List<JobTitleVM>();
            foreach (var jobTtl in jobTitleService.GetAll().ToList())
            {
                jobTitles.Add(new JobTitleVM() { JobTitleId = jobTtl.Id, JobTitleName = jobTtl.Name });
            }
            return jobTitles;
        }

        [ActionName("PostEmployee")]
        public IHttpActionResult PostEmployee(EmployeeVM employeeVM)
        {
            if (employeeVM == null)
            {
                return BadRequest("Invalid data.");
            }

                Employee employee = new Employee()
                {
                    FirstName = employeeVM.FirstName,
                    LastName = employeeVM.LastName,
                    EmploymentDate = employeeVM.EmploymentDate,
                    Rate = employeeVM.Rate,
                    JobTitleId = employeeVM.JobTitleId
                };

                employeeService.Insert(employee);

            return Ok();
        }

        [HttpDelete]
        [ActionName("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Employee id");

            Employee employee = employeeService.GetByID(id);
            if (employee == null)
            {
                return NotFound();
            }

            employeeService.Delete(employee);

            return Ok(employee);
        }

    }
}