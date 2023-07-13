using ECommerceLP.Core.Mongo.Abstractions.Document;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Mongo.Abstractions
{
    public partial interface IMongoRepository<TDocument> where TDocument : DocumentBase
    {
        IMongoQueryable<TDocument> CreateQuery(
            Expression<Func<TDocument, bool>> predicate = null,
            Func<IMongoQueryable<TDocument>, IOrderedMongoQueryable<TDocument>> orderBy = null);

        Task<IList<TResult>> FindManyAsync<TResult>(
            Expression<Func<TDocument, TResult>> selector,
            Expression<Func<TDocument, bool>> predicate = null,
            Func<IMongoQueryable<TDocument>, IOrderedMongoQueryable<TDocument>> orderBy = null,
            int topCount = 1000,
            CancellationToken cancellationToken = default)
            where TResult : class;

        Task AddAsync(TDocument document, CancellationToken cancellationToken = default);

        Task<TDocument> FindAsync(
         Expression<Func<TDocument, bool>> predicate = null,
         Func<IMongoQueryable<TDocument>, IOrderedMongoQueryable<TDocument>> orderBy = null,
         CancellationToken cancellationToken = default);

        Task UpdateAsync(
          Func<UpdateDefinitionBuilder<TDocument>, UpdateDefinition<TDocument>> update,
          Expression<Func<TDocument, bool>> predicate,
          CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(
           Expression<Func<TDocument, bool>> predicate = null,
           CancellationToken cancellationToken = default);
        Task PushAsync(
                  Func<UpdateDefinitionBuilder<TDocument>, UpdateDefinition<TDocument>> update,
                  Expression<Func<TDocument, bool>> predicate,
                  CancellationToken cancellationToken = default);
    }
}
