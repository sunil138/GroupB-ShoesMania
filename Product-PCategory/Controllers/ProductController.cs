using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_PCategory.Commands.ProductCommands;
using Product_PCategory.Models;
using Product_PCategory.Models.DTO;
using Product_PCategory.Query.ProductCategoryQuerys;
using Product_PCategory.Query.ProductsQuery;

namespace Product_PCategory.Controllers
{
    [EnableCors("product")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllProducts")]
        //[Authorize(Roles ="User")]
        public async Task<IActionResult> GetAllProducts()
        {
            var getAllProducts = await _mediator.Send(new GetAllProductsQuery());
            return Ok(getAllProducts);
        }

        [HttpGet]
        [Route("getProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productById = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(productById);
        }

        [HttpPost]
        [Route("addNewProduct")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductRequestDto newProduct)
        {
            var message = await _mediator.Send(new AddProductCommand(newProduct));
            return StatusCode(201, new { Message = message });
        }

        [HttpDelete]
        [Route("deleteProduct/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var message = await _mediator.Send(new DeleteProductCommand(id));
            return StatusCode(201, new { Message = message });
        }

        [HttpPut]
        [Route("updateProduct")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductRequestDto updatedProduct)
        {
            var message = await _mediator.Send(new UpdateProductCommand(updatedProduct));
            return StatusCode(201,new {Message = message });
        }

    }
}
