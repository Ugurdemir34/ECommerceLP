using AutoMapper;
using Catalogs.Common.Dtos;
using Catalogs.Domain.Aggregate.CategoryAggregate;
using ECommerceLP.Application.Interfaces.Abstract;
using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Collections.Concrete;
using ECommerceLP.Common.Collections.Extensions;
using ECommerceLP.Infrastructure.UnitOfWork;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Catalogs.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, List<CategoryDto>>,IQueryCacheable
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // if(redis==null)
            //{ var data _map getAllCategories() }
            // else { redis.cache[0].where (query)
            //returl page

            var repo = _unitOfWork.GetQueryRepository<Catalogs.Domain.Aggregate.CategoryAggregate.Category>();
            var list = await repo.ListAsync(c => c.IsDeleted == false);
            list = list.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();
            var result = _mapper.Map<List<CategoryDto>>(list);
            return result;
        }
        
    }
}
