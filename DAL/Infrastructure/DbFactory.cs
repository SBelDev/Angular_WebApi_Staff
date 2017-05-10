using DAL;

namespace DAL.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        private DbModelContext dataContext;

        public DbModelContext Init()
        {
            return dataContext ?? (dataContext = new DbModelContext());
        }
    }
}
