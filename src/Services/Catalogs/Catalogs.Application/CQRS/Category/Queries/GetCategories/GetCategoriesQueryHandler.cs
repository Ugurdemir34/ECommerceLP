using AutoMapper;
using Catalogs.Common.Dtos;
using Catalogs.Persistence.Context;
using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.CQRS.Abstraction;
using ECommerceLP.Core.CQRS.Abstraction.Query;
using ECommerceLP.Core.UnitOfWork.Abstraction;

namespace Catalogs.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, PagedList<CategoryDto>>,IQueryCacheable
    {
        private readonly IUnitOfWork<CatalogContext> _unitOfWork;
        private IMapper _mapper;
        public GetCategoriesQueryHandler(IUnitOfWork<CatalogContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetQueryRepository<Catalogs.Domain.Aggregate.CategoryAggregate.Category>();
            var list = await repo.QueryPagedListAsync(c => c.IsDeleted != false, index: request.PageIndex, size: request.PageSize);
            var result = _mapper.Map<PagedList<CategoryDto>>(list);
            return result;
        }
        
    }
}
