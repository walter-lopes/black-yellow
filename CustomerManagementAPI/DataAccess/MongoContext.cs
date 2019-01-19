using MongoDB.Driver;
namespace CustomerManagementAPI.DataAccess
{
    public class MongoContext : IDbContext
    {
        public string ConnectionString { get; set; }
        public string DataBase { get; set; }


        public MongoContext() { }

        public IMongoDatabase Context
        {
            get
            {
                MongoUrl url = new MongoUrl(this.ConnectionString);
                MongoClient client = new MongoClient(url);
                return client.GetDatabase(this.DataBase);
            }
        }
    }
}
