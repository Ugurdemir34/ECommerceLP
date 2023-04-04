using Catalogs.Application.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Common.Collections.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IQuery<IPagedList<CategoryDto>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public GetCategoriesQuery(CategoryRequest request)
        {
            PageSize = request.PageSize;
            PageIndex = request.PageIndex;
        }
    }
}
