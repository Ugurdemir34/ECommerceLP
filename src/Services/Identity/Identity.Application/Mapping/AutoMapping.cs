using AutoMapper;
using Identity.Application.CQRS.Users.Commands.CreateUser;
using Identity.Domain.Aggregate.UserAggregate.Entities;

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
