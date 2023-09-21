using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Common.Requests
{
    public class CreateCategoryRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
