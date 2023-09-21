using Bff.Application.Catalog.Command.CreateCategory;
using Catalogs.Common.Dtos;
using Catalogs.Common.Requests;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.RemoteCall;
namespace Bff.Application.Catalog.Command.CreateCategory
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICatalogRemoteCallService _catalogRemoteCallService;

        public CreateCategoryHandler(ICatalogRemoteCallService catalogRemoteCallService)
        {
            _catalogRemoteCallService = catalogRemoteCallService;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return (await _catalogRemoteCallService.CreateCategory(new CreateCategoryRequest() { Description = request.Description, Title = request.Title }, cancellationToken)).Body;
        }
    }
}
