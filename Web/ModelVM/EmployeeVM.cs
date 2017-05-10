using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ModelVM
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int Rate { get; set; }

        public string JobTitleName { get; set; }

        public int JobTitleId { get; set; }
    }
}