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
namespace Catalogs.Application.CQRS.Category.Command.CreateCategory
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
