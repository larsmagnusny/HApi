using LiteDB;

namespace HApi.DataAccess
{
    public interface IHDbContext
    {
        LiteDatabase Database { get; }
    }
}