using Catalogs.Common.Dtos;
using Catalogs.Common.Requests;
using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Abstraction.RemoteCall;
using ECommerceLP.Core.RemoteCall.Attributes;

namespace Identity.Common.RemoteCall
{
    public interface ICatalogRemoteCallService : IRemoteCallService
    {
        [CustomPost("/api/catalogs/getcategories")]
        Task<Response<PagedList<CategoryDto>>> GetCategories(CategoryRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/catalogs/getcategorybyid")]
        Task<Response<CategoryDto>> GetCategoryById(CategoryByIdRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/catalogs/create")]
        Task<Response<CategoryDto>> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/catalogs/delete")]
        Task<Response<bool>> DeleteCategory(DeleteCategoryRequest request, CancellationToken cancellationToken);
    }
}
