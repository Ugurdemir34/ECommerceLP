using Catalogs.Application.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.CQRS.Abstraction.Query;

namespace Catalogs.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IQuery<PagedList<CategoryDto>>
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
