using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Common.Requests
{
    public class CategoryRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
