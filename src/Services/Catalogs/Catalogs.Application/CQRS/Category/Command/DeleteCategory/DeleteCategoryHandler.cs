﻿using AutoMapper;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = Catalogs.Domain.Aggregate.CategoryAggregate.Category;
namespace Catalogs.Application.CQRS.Category.Command.DeleteCategory
{
    public class DeleteCategoryHandler : ICommandHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public DeleteCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetCommandRepository<CategoryEntity>();
            await repo.DeleteAsync(request.CategoryId);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}