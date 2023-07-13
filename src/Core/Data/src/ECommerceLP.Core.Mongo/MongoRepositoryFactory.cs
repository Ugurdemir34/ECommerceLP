using ECommerceLP.Core.Mongo.Abstractions;
using ECommerceLP.Core.Mongo.Abstractions.Document;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Mongo
{
    public class MongoRepositoryFactory<TContext> : IMongoRepositoryFactory<TContext> where TContext:MongoContext
    {
        private readonly ConcurrentDictionary<string, object> _repositories;

        private readonly MongoContext _context;
        public MongoRepositoryFactory(MongoContext context)
        {
            _repositories = new ConcurrentDictionary<string, object>();
            _context = context;
        }


        public IMongoRepository<TDocument> GetRepository<TDocument>(string collectionName = null) where TDocument : DocumentBase
        {
            return this.CreateOrGetRepository<TDocument>(collectionName);
        }
        private MongoRepository<TDocument> CreateOrGetRepository<TDocument>(
            string collectionName)
            where TDocument : DocumentBase
        {
            return (MongoRepository<TDocument>)this._repositories.GetOrAdd(
                !string.IsNullOrEmpty(collectionName)
                    ? collectionName
                    : typeof(TDocument).Name,
                new MongoRepository<TDocument>(
                    this._context,
                    collectionName));
        }
    }
}
