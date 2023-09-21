using Bff.Application.Catalog.Command.DeleteCategory;
using Catalogs.Common.Requests;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.RemoteCall;
namespace Catalogs.Application.CQRS.Category.Command.DeleteCategory
{
    public class DeleteCategoryHandler : ICommandHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICatalogRemoteCallService _catalogRemoteCallService;

        public DeleteCategoryHandler(ICatalogRemoteCallService catalogRemoteCallService)
        {
            _catalogRemoteCallService = catalogRemoteCallService;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return (await _catalogRemoteCallService.DeleteCategory(new DeleteCategoryRequest() {CategoryId=request.CategoryId }, cancellationToken)).Body;
        }
    }
}
