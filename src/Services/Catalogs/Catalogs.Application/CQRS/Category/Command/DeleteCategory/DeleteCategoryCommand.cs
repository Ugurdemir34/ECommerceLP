using Catalogs.Application.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Application.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Application.CQRS.Category.Command.DeleteCategory
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
