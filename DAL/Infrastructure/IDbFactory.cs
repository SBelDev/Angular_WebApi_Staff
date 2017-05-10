using DAL;

namespace DAL.Infrastructure
{
    public interface IDbFactory
    {
        DbModelContext Init();
    }
}
