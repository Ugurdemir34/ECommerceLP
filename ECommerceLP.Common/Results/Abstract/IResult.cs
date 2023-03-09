using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Results.Abstract
{
    public interface IResult
    {
        public int StatusCode { get; }
        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
