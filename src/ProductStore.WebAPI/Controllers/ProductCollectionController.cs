using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductCollectionsQueryRequest getAllProductCollectionsQueryRequest)
        {
            GetAllProductCollectionsQueryResponse response = await _mediator.Send(getAllProductCollectionsQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetProductCollectionByIdQueryRequest getProductCollectionByIdQueryRequest)
        {
            GetProductCollectionByIdQueryResponse response = await _mediator.Send(getProductCollectionByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] AddProductCollectionCommandRequest addProductCollectionCommandRequest)
        {
            AddProductCollectionCommandResponse response = await _mediator.Send(addProductCollectionCommandRequest);
            return Ok(response);
        }

        [HttpPut()]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCollectionCommandRequest updateProductCollectionCommandRequest)
        {
            UpdateProductCollectionCommandResponse response = await _mediator.Send(updateProductCollectionCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCollectionCommandRequest deleteProductCollectionCommandRequest)
        {
            DeleteProductCollectionCommandResponse response = await _mediator.Send(deleteProductCollectionCommandRequest);
            return Ok(response);
        }

        [HttpPost("{Id}/[action]")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Complete([FromRoute] CompleteProductCollectionCommandRequest deleteProductCollectionCommandRequest)
        {
            CompleteProductCollectionCommandResponse response = await _mediator.Send(deleteProductCollectionCommandRequest);
            return Ok(response);
        }

        [HttpPost("{Id}/[action]")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve([FromRoute] ApproveProductCollectionCommandRequest deleteProductCollectionCommandRequest)
        {
            ApproveProductCollectionCommandResponse response = await _mediator.Send(deleteProductCollectionCommandRequest);
            return Ok(response);
        }

        [HttpPost("{Id}/[action]")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject([FromRoute] RejectProductCollectionCommandRequest deleteProductCollectionCommandRequest)
        {
            RejectProductCollectionCommandResponse response = await _mediator.Send(deleteProductCollectionCommandRequest);
            return Ok(response);
        }
    }
}