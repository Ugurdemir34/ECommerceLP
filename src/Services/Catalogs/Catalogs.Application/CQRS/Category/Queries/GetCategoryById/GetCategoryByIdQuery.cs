using Catalogs.Application.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Application.Messaging.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
