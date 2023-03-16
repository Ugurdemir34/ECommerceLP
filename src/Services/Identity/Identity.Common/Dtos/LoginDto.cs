using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Common.Dtos
{
    public class LoginDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
