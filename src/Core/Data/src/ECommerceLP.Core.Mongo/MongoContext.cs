using ECommerceLP.Core.Abstraction.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Mongo
{
    public class MongoContext
    {
        public IMongoDatabase Database { get; }
        public MongoContext(IOptions<DatabaseSettings> option)
        {
            var client = new MongoClient(option.Value.ConnectionString);
            Database = client.GetDatabase(option.Value.Database);
        }

    }
}
