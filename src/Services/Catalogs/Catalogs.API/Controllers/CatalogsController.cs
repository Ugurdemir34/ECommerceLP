using Catalogs.Application.CQRS.Category.Command.CreateCategory;
using Catalogs.Application.CQRS.Category.Command.DeleteCategory;
using Catalogs.Application.CQRS.Category.Queries.GetCategories;
using Catalogs.Application.CQRS.Category.Queries.GetCategoryById;
using Catalogs.Application.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.API.Controllers
{
    public class CatalogsController : BaseApi
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
        [HttpGet]
        [Route("GetCategories")]
        [ProducesResponseType(typeof(PagedList<CategoryDto>), StatusCodes.Status200OK)]
        public async Task<Response<PagedList<CategoryDto>>> GetCategories(CategoryRequest request, CancellationToken cancellationToken)
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
        public async Task<bool> DeleteCategory(DeleteCategoryRequest request,CancellationToken cancellationToken)
        {
            var command = new DeleteCategoryCommand(request);
            var result = await _processor.ProcessAsync(command,cancellationToken);
            return result;
        }
        #endregion
    }
}
