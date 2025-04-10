using MediatR;
using MediatRWithEFCoreDemo.Features.Products;
using MediatRWithEFCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatRWithEFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        // GET api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        // PUT api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            try
            {
                var updatedProduct = await _mediator.Send(command);
                return Ok(updatedProduct);  // Return the updated product
            }
            catch (KeyNotFoundException)
            {
                return NotFound();  // If the product is not found
            }
        }

        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);

            bool result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();  // If the product is not found
            }

            return NoContent();  // Return 204 No Content on successful deletion
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10,
                                                        [FromQuery] string? sortBy = null, [FromQuery] bool ascending = true,
                                                        [FromQuery] string? filterName = null, [FromQuery] decimal? minPrice = null,
                                                        [FromQuery] decimal? maxPrice = null)
        {
            var query = new GetAllProductsQuery(pageNumber, pageSize, sortBy, ascending, filterName, minPrice, maxPrice);

            var (products, totalCount) = await _mediator.Send(query);

            var response = new
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Products = products
            };

            return Ok(response);
        }
    }
}
