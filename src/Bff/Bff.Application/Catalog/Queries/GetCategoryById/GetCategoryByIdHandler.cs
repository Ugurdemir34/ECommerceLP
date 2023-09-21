using Catalogs.Common.Dtos;
using Catalogs.Common.Requests;
using ECommerceLP.Core.CQRS.Abstraction.Query;
using Identity.Common.RemoteCall;
namespace Catalogs.Application.CQRS.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICatalogRemoteCallService _catalogRemoteCallService;

        public GetCategoryByIdHandler(ICatalogRemoteCallService catalogRemoteCallService)
        {
            _catalogRemoteCallService = catalogRemoteCallService;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _catalogRemoteCallService.GetCategoryById(new CategoryByIdRequest() { CategoryId = request.CategoryId }, cancellationToken)).Body;
        }
    }
}
