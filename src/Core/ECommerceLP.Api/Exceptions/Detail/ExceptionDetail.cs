using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Api.Exceptions.Detail
{
    public class ExceptionDetail
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public ExceptionDetail()
        {
            Type = GetType().Name;
        }
    }
}
