using Catalogs.Application.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Application.CQRS.Category.Command.CreateCategory
{
    public class CreateCategoryCommand : ICommand<CategoryDto>
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime ModifiedDate { get; private set; } = DateTime.Now;
        public bool IsDeleted { get; private set; } = false;
        public CreateCategoryCommand(CreateCategoryRequest request)
        {
            Id = Guid.NewGuid();
            Title = request.Title;
            Description = request.Description;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
