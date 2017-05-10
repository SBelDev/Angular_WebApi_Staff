using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class DbModelContextInitializer : DropCreateDatabaseIfModelChanges<DAL.DbModelContext>
    {
        protected override void Seed(DbModelContext context)
        {
            IList<JobTitle> jobTitles = new List<JobTitle>();

            jobTitles.Add(new JobTitle() { Name = "CEO" });
            jobTitles.Add(new JobTitle() { Name = "QA" });
            jobTitles.Add(new JobTitle() { Name = "Developer" });
            jobTitles.Add(new JobTitle() { Name = "Bissness Analyst" });
            jobTitles.Add(new JobTitle() { Name = "Founder & CEO" });

            foreach (JobTitle jobTlt in jobTitles)
                context.JobTitles.Add(jobTlt);

            context.SaveChanges();
        }
    }
}
