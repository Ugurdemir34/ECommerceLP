using AutoMapper;
using Catalogs.Common.Dtos;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = Catalogs.Domain.Aggregate.CategoryAggregate.Category;
namespace Catalogs.Application.CQRS.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetQueryRepository<CategoryEntity>();
            var category = await repo.GetAsync(c => c.Id == request.CategoryId);
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }
    }
}
