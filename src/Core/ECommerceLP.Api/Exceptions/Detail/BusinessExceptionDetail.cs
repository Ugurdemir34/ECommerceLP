using ECommerceLP.Api.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Api.Exceptions.Detail
{
    public class BusinessExceptionDetail:ExceptionDetail
    {
        public BusinessExceptionDetail
            (BusinessException exception,
            int errorCode,
            string message)
        {
            this.Title = $"Business Exception";
            this.Message = message ;
            this.ErrorCode = errorCode ;
        }
    }
}
