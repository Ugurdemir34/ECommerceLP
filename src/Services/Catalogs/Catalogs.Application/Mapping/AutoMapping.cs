using AutoMapper;
using Catalogs.Application.CQRS.Category.Command.CreateCategory;
using Catalogs.Common.Dtos;
using Catalogs.Domain.Aggregate.CategoryAggregate;
using ECommerceLP.Core.Abstraction.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Application.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<PagedList<CategoryDto>, PagedList<Category>>().ReverseMap();
        }
    }
}
