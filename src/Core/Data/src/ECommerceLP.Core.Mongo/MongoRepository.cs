using ECommerceLP.Core.Mongo.Abstractions;
using ECommerceLP.Core.Mongo.Abstractions.Attributes;
using ECommerceLP.Core.Mongo.Abstractions.Document;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Mongo
{
    public partial class MongoRepository<TDocument> : IMongoRepository<TDocument>
       where TDocument : DocumentBase
    {
        protected IMongoCollection<TDocument> Collection { get; }
        private readonly MongoContext _mongoContext;
        public string CollectionName { get; }
        private const int TopCount = 1000;

        public MongoRepository(MongoContext mongoContext, string collectionName = default)
        {
            _mongoContext = mongoContext; this.CollectionName = !string.IsNullOrEmpty(collectionName)
                ? collectionName
                : this.GetCollectionName();
            this.Collection = this._mongoContext.Database.GetCollection<TDocument>(this.CollectionName);

        }
        public IMongoQueryable<TDocument> CreateQuery(Expression<Func<TDocument, bool>> predicate = null, Func<IMongoQueryable<TDocument>, IOrderedMongoQueryable<TDocument>> orderBy = null)
        {
            var query = this.Collection.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query;
        }
        public async Task<IList<TResult>> FindManyAsync<TResult>(
            Expression<Func<TDocument, TResult>> selector,
            Expression<Func<TDocument, bool>> predicate = null,
            Func<IMongoQueryable<TDocument>, IOrderedMongoQueryable<TDocument>> orderBy = null,
            int topCount = TopCount,
            CancellationToken cancellationToken = default)
            where TResult : class
        {
            var query = this.CreateQuery(predicate, orderBy);

            if (topCount != -1)
            {
                query = query.Take(topCount);
            }

            return await Task.Run(() => query.Select(selector.Compile()).ToList());
        }
        public async Task<TDocument> FindAsync(
            Expression<Func<TDocument, bool>> predicate = null,
            Func<IMongoQueryable<TDocument>, IOrderedMongoQueryable<TDocument>> orderBy = null,
            CancellationToken cancellationToken = default)
        {
            var query = this.CreateQuery(predicate, orderBy);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
        public async Task AddAsync(
            TDocument document,
            CancellationToken cancellationToken = default)
        {
            //this.SetCreationProperties(document);
            //this.SetModificationProperties(document);
            await this.Collection.InsertOneAsync(document, cancellationToken: cancellationToken);
        }
        public async Task UpdateAsync(
            Func<UpdateDefinitionBuilder<TDocument>, UpdateDefinition<TDocument>> update,
            Expression<Func<TDocument, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var filter = new FilterDefinitionBuilder<TDocument>().Where(predicate);

            var updateDefinitionBuilder = new UpdateDefinitionBuilder<TDocument>();
            var updateDefinition = update(updateDefinitionBuilder);
            await this.Collection.UpdateManyAsync(filter, updateDefinition, cancellationToken: cancellationToken);
        }
        public async Task<bool> AnyAsync(
            Expression<Func<TDocument, bool>> predicate = null,
            CancellationToken cancellationToken = default)
        {
            return await this.Collection.AsQueryable()
                .AnyAsync(predicate, cancellationToken);
        }
        public async Task PushAsync(
                  Func<UpdateDefinitionBuilder<TDocument>, UpdateDefinition<TDocument>> update,
                  Expression<Func<TDocument, bool>> predicate,
                  CancellationToken cancellationToken = default)
        {
            var filter = new FilterDefinitionBuilder<TDocument>().Where(predicate);
            var updateDefinitionBuilder = new UpdateDefinitionBuilder<TDocument>();
            var updateDefinition = update(updateDefinitionBuilder);
            var updateOptions = new UpdateOptions { IsUpsert = true };
            await this.Collection.UpdateManyAsync(filter, updateDefinition, updateOptions, cancellationToken: cancellationToken);

        }
        private string GetCollectionName()
        {
            var infoAttribute = typeof(TDocument).GetCustomAttribute<CollectionInfoAttribute>();
            return infoAttribute != null && !string.IsNullOrEmpty(infoAttribute.CollectionName)
                ? infoAttribute.CollectionName
                : typeof(TDocument).Name.ToLower(CultureInfo.CurrentCulture);
        }
    }
}
