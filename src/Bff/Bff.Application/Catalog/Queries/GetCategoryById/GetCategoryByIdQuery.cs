using Bff.Core.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Core.CQRS.Abstraction.Query;

namespace Catalogs.Application.CQRS.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IQuery<CategoryDto>
    {
        public Guid CategoryId { get; set; }
        public GetCategoryByIdQuery(CategoryByIdRequest request)
        {
            CategoryId = request.CategoryId;
        }
    }
}
