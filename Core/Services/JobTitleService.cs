using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL;

namespace Core.Services
{
    public class JobTitleService : BaseService<JobTitle>, IService<JobTitle>
    {
        public JobTitleService(IRepository<JobTitle> genericRepository) : base(genericRepository)
        {
        }
    }
}
