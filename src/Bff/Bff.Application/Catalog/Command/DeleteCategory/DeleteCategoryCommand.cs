using Bff.Core.Requests.Category;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Catalog.Command.DeleteCategory
{
    public class DeleteCategoryCommand : ICommand<bool>
    {
        public Guid CategoryId { get; set; }
        public DeleteCategoryCommand(DeleteCategoryRequest request)
        {
            CategoryId = request.CategoryId;
        }
    }
}
