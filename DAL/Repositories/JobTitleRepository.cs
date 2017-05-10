using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL;

namespace DAL.Repositories
{
    public class JobTitleRepository : BaseRepository<JobTitle>, IRepository<JobTitle>
    {
        public JobTitleRepository(IDBUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
