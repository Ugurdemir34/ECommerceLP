using ECommerceLP.Core.Mongo.Abstractions;
using ECommerceLP.Core.Mongo.Abstractions.Document;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Mongo.Abstractions
{
    public interface IMongoRepositoryFactory<TContext>
    {
        IMongoRepository<TDocument> GetRepository<TDocument>(string collectionName = default)
          where TDocument : DocumentBase;
    }
}