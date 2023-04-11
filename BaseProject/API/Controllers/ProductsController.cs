using Business.Abstract;
using Business.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //Get Requests
        [HttpGet("getallproducts")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getsingleproduct")]
        public IActionResult GetSingleProductById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("productbycategory")]
        public IActionResult GetBycategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("productwithdetails")]
        public IActionResult GetProductDetails()
        {
            var result = _productService.GetProductDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        //Post Requests
        [HttpPost("add")]
        [Authorize(Roles = "product.add")]
        public IActionResult AddNewProduct(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

       [HttpPost("delete")]
       public IActionResult DeleteProduct(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

    }
}
