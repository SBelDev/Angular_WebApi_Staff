using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.UnitOfWork
{
    public interface IDBUnitOfWork : IUnitOfWork
    {
        DbModelContext Db { get; }
    }
}
