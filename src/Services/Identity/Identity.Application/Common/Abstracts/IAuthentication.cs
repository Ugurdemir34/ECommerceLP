using Identity.Application.CQRS.Commands;
using Identity.Common.Dtos;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Common.Abstracts
{
    public interface IAuthentication
    {
        string HashPassword(string password);
        Task<LoginDto> GenerateTokenAsync(User user);
    }
}
