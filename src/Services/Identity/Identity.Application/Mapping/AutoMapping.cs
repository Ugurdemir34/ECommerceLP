using AutoMapper;
using Identity.Application.Contracts.User;
using Identity.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RegisterRequest, CreateUserDTO>();
        }
    }
}
