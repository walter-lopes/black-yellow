using MongoDB.Driver;
namespace ProductManagementAPI.DataAccess
{
    public interface IDbContext
    {
        IMongoDatabase Context { get; }
    }
}
