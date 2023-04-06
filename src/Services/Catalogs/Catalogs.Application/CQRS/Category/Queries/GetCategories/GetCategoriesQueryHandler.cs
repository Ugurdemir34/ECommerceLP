using AutoMapper;
using Catalogs.Common.Dtos;
using Catalogs.Domain.Aggregate.CategoryAggregate;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Collections.Concrete;
using ECommerceLP.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Catalogs.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IPagedList<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IPagedList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetQueryRepository<Catalogs.Domain.Aggregate.CategoryAggregate.Category>();
            var list = await repo.QueryPagedListAsync(c => c.IsDeleted != false, index: request.PageIndex, size: request.PageSize);
            var result = _mapper.Map<PagedList<CategoryDto>>(list);
            return result;
        }
    }
}
