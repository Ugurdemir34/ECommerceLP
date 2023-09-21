using Bff.Application.Catalog.Queries.GetCategories;
using Catalogs.Common.Dtos;
using Catalogs.Common.Requests;
using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.CQRS.Abstraction.Query;
using Identity.Common.RemoteCall;

namespace Catalogs.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, PagedList<CategoryDto>>
    {
        private readonly ICatalogRemoteCallService _catalogRemoteCallService;

        public GetCategoriesQueryHandler(ICatalogRemoteCallService catalogRemoteCallService)
        {
            _catalogRemoteCallService = catalogRemoteCallService;
        }

        public async Task<PagedList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return (await _catalogRemoteCallService.GetCategories(new CategoryRequest() { PageIndex=request.PageIndex,PageSize=request.PageSize }, cancellationToken)).Body;
        }

    }
}
