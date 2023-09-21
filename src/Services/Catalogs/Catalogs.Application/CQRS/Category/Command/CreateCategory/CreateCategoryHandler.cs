using AutoMapper;
using Catalogs.Common.Dtos;
using Catalogs.Persistence.Context;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = Catalogs.Domain.Aggregate.CategoryAggregate.Category;
namespace Catalogs.Application.CQRS.Category.Command.CreateCategory
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IUnitOfWork<CatalogContext> _unitOfWork;
        private IMapper _mapper;
        public CreateCategoryHandler(IMapper mapper, IUnitOfWork<CatalogContext> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetCommandRepository<CategoryEntity>();
            var added = _mapper.Map<CategoryEntity>(request);
            await repo.AddAsync(added);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CategoryDto>(request);
        }
    }
}
