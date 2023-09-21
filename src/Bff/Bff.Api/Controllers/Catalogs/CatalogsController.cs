using Baskets.Common.Dtos;
using Bff.Application.Baskets.Command.BuyBasket;
using Bff.Application.Baskets.Command.CreateBasket;
using Bff.Application.Catalog.Command.CreateCategory;
using Bff.Application.Catalog.Command.DeleteCategory;
using Bff.Application.Catalog.Queries.GetCategories;
using Bff.Application.Identity.Command.CreateUser;
using Bff.Application.Identity.Command.LoginUser;
using Bff.Core.Requests.Baskets;
using Bff.Core.Requests.Category;
using Bff.Core.Requests.Identity;
using Catalogs.Application.CQRS.Category.Queries.GetCategoryById;
using Catalogs.Common.Dtos;
using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.BFF.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using Identity.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Api.Controllers.Catalogs
{
    public class CatalogsController : BaseApiBff
    {
        #region Variables
        private readonly IProcessor _processor;

        #endregion
        #region Constructor
        public CatalogsController(IProcessor processor)
        {
            _processor = processor;
        }
        #endregion
        #region GetCategoriesAsync
        [HttpPost("getcategories")]
        //[Route("GetCategories")]
        //[ProducesResponseType(typeof(PagedList<CategoryDto>), StatusCodes.Status200OK)]
        public async Task<Response<PagedList<CategoryDto>>> GetCategories([FromBody] CategoryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoriesQuery(request);
            var result = await _processor.ProcessAsync(query, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
        #region GetCategoryById
        [Authorize]
        [HttpGet]
        [Route("GetCategoryById")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        public async Task<Response<CategoryDto>> GetCategoryById([FromBody] CategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery(request);
            var result = await _processor.ProcessAsync(query, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
        #region CreateCategory
        //[Authorize]
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        public async Task<Response<CategoryDto>> CreateCategory([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateCategoryCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
        #region DeleteCategory
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<bool> DeleteCategory(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteCategoryCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return result;
        }
        #endregion
    }
}
