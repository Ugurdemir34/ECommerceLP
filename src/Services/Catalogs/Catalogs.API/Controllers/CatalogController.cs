﻿using Catalogs.Application.CQRS.Category.Queries.GetCategories;
using Catalogs.Application.CQRS.Category.Queries.GetCategoryById;
using Catalogs.Application.Requests.Category;
using Catalogs.Common.Dtos;
using ECommerceLP.Api.Controllers;
using ECommerceLP.Application.CQRS.Abstract;
using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Messaging.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.API.Controllers
{
    public class CatalogController : BaseApi
    {
        private readonly IProcessor _processor;
        public CatalogController(IProcessor processor)
        {
            _processor = processor;
        }
        [Authorize]
        [HttpGet("GetCategories")]
        [ProducesResponseType(typeof(IPagedList<CategoryDto>), StatusCodes.Status200OK)]
        public async Task<Response<IPagedList<CategoryDto>>> GetCategoriesAsync([FromBody] CategoryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoriesQuery(request);
            var result = await _processor.ProcessAsync(query, cancellationToken);
            return this.ProduceResponse(result);
        }
        [Authorize]
        [HttpGet("GetCategoryById")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        public async Task<Response<CategoryDto>> GetCategoryById([FromBody] CategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery(request);
            var result = await _processor.ProcessAsync(query, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
