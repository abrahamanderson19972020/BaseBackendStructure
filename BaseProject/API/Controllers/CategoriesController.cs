using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //Get Requests
        [HttpGet("getallcategories")]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAll();
            if(result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpGet("getsinglecategory")]
        public IActionResult GetSingleCategory(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        //Post Requests
        [HttpPost("add")]
        public IActionResult AddCategory(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult UpdateCategory(Category category)
        {
            var result = _categoryService.Update(category); 
            if(result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult DeleteCategory(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
