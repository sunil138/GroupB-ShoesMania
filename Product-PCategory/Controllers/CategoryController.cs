using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_PCategory.Commands.CategoryCommands;
using Product_PCategory.Handler.CategoryHandler;
using Product_PCategory.Models;
using Product_PCategory.Query.ProductCategoryQuerys;

namespace Product_PCategory.Controllers
{
    [EnableCors("product")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet]
        [Route("GetCategoryList")]
        public async Task<List<ProductCategory>> GetCategoryList()
        {
            var categoryList = await _mediator.Send(new ProductCategoryQuery());
            return categoryList;
        }

        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public async Task<ProductCategory> GetCategoryById(int id)
        {
            var categoryById = await _mediator.Send(new getCategoryByIdQuery(id));
            return categoryById;
        }

        [HttpGet]
        [Route("getCategoryByName")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var categoryByName = await _mediator.Send(new getCategoryByName(name));
            return Ok(categoryByName);
        }

        [HttpGet]
        [Route("getCategoryBySubCategoryName")]
        public async Task<IActionResult> GetCategoryBySubCategoryName(string name)
        {
            var categoryBySubCategoryName = await _mediator.Send(new getCategoryBySubCategoryNameQuery(name));
            return Ok(categoryBySubCategoryName);
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddNewCategory(ProductCategory newCategory)
        {
            var message = await _mediator.Send(new AddCategoryCommand(newCategory));
            return StatusCode(201, new { Message = message });
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var message= await _mediator.Send(new DeleteCategoryCommand(id));
            return StatusCode(200, new { Message = message });
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(ProductCategory updateCategory)
        {
            var message = await _mediator.Send(new UpdateCategoryCommand(updateCategory));
            return StatusCode(201,new { Message = message});
        }

       




    }
}
