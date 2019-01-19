using MongoDB.Driver;
namespace CustomerManagementAPI.DataAccess
{
    public interface IDbContext
    {
        IMongoDatabase Context { get; }
    }
}
