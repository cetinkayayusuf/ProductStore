using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Features.Category.Commands.AddCategory;
using ProductStore.Application.Features.Category.Commands.DeleteCategory;
using ProductStore.Application.Features.Category.Commands.UpdateCategory;
using ProductStore.Application.Features.Category.Queries.GetAllCategories;
using ProductStore.Application.Features.Category.Queries.GetCategoryById;

namespace ProductStore.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin,User")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQueryRequest getAllCategoriesQueryRequest)
        {
            GetAllCategoriesQueryResponse response = await _mediator.Send(getAllCategoriesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetCategoryByIdQueryRequest getCategoryByIdQueryRequest)
        {
            GetCategoryByIdQueryResponse response = await _mediator.Send(getCategoryByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Add([FromBody] AddCategoryCommandRequest addCategoryCommandRequest)
        {
            AddCategoryCommandResponse response = await _mediator.Send(addCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPut()]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            DeleteCategoryCommandResponse response = await _mediator.Send(deleteCategoryCommandRequest);
            return Ok(response);
        }
    }
}