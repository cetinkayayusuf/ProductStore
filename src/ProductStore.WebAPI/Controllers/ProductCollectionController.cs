using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Features.ProductCollection.Commands.AddProductCollection;
using ProductStore.Application.Features.ProductCollection.Commands.ApproveProductCollection;
using ProductStore.Application.Features.ProductCollection.Commands.CompleteProductCollection;
using ProductStore.Application.Features.ProductCollection.Commands.DeleteProductCollection;
using ProductStore.Application.Features.ProductCollection.Commands.RejectProductCollection;
using ProductStore.Application.Features.ProductCollection.Commands.UpdateProductCollection;
using ProductStore.Application.Features.ProductCollection.Queries.GetAllProductCollections;
using ProductStore.Application.Features.ProductCollection.Queries.GetByIdProductCollection;

namespace ProductStore.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin,User")]
    public class ProductCollectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCollectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductCollectionsQueryRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            GetAllProductCollectionsQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetProductCollectionByIdQueryRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            GetProductCollectionByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] AddProductCollectionCommandRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            AddProductCollectionCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut()]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCollectionCommandRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            UpdateProductCollectionCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCollectionCommandRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            DeleteProductCollectionCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("{Id}/[action]")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Complete([FromRoute] CompleteProductCollectionCommandRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            CompleteProductCollectionCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("{Id}/[action]")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve([FromRoute] ApproveProductCollectionCommandRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            ApproveProductCollectionCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("{Id}/[action]")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject([FromRoute] RejectProductCollectionCommandRequest request)
        {
            request.UserId = HttpContext.User.GetLoggedInUserId();
            RejectProductCollectionCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}