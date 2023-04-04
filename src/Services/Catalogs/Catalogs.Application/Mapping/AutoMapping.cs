﻿using AutoMapper;
using Catalogs.Common.Dtos;
using Catalogs.Domain.Aggregate.CategoryAggregate;
using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Collections.Concrete;
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
            CreateMap<PagedList<CategoryDto>, PagedList<Category>>().ReverseMap();
        }
    }
}
