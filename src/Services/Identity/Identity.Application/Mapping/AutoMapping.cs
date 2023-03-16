using AutoMapper;
using Identity.Application.Requests.User;
using Identity.Application.CQRS.User.Commands.CreateUser;
using Identity.Common.Dtos;
using Identity.Domain.Aggregate.UserAggregate.Entities;
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
            CreateMap<CreateUserCommand, User>().ReverseMap();
        }
    }
}
