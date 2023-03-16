using Identity.Common.Dtos;
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
        LoginDto GenerateToken(string userName,Guid userId); // Primitive Type ile yap !
    }
}
