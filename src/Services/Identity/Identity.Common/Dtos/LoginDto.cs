using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Common.Dtos
{
    public class LoginDto
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
