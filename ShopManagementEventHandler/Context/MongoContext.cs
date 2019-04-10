using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementEventHandler.Context
{
    public class MongoContext
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
