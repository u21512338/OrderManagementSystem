using OrderManagementSystem.Models;
using OrderManagementSystem.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IRepository _repository;

        public ProductController(IRepository productRepository)
        {
            _repository = productRepository;
        }


        /* C */
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductViewModel product)
        {
            try
            {
                var results = await _repository.AddProductAsync(product);
                if (results == 200)
                {
                    var res = new OkObjectResult(new { message = "Successfully Added " + product.ProductName, currentDate = DateTime.Now, StatusCode = 200 });
                    return res;
                }
                else
                {
                    var res = new OkObjectResult(new { message = "Failed To Add Product Please check your code", currentDate = DateTime.Now, StatusCode = 501 });
                    return res;
                }

            }
            catch (Exception)
            {
                var res = new OkObjectResult(new { message = "Internal Server Error. Please contact support.", currentDate = DateTime.Now, StatusCode = 500 });
                return res;

            }
        }


        /* R - ALL */
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var results = await _repository.GetAllProductAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        /* R - One */
        [HttpGet]
        [Route("GetProduct/{ProductId}")]
        public async Task<IActionResult> GetProduct(int ProductId)
        {
            try
            {
                var result = await _repository.GetProductAsync(ProductId);
                if (result.response == 404)
                {
                    return StatusCode(404, "Cannot Find Specified Product");
                }
                else if (result.response == 200)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("Failed To Find Product Please check your code");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        /* U */
        [HttpPut]
        [Route("UpdateProduct/{ProductId}")]
        public async Task<IActionResult> UpdateProduct(int ProductId, ProductViewModel product)
        {
            try
            {
                var result = await _repository.UpdateProductAsync(ProductId, product);
                if (result == 200)
                {
                    var res = new OkObjectResult(new { message = "Successfully Updated ", currentDate = DateTime.Now, StatusCode = 200 });
                    return res;
                }
                else if (result == 404)
                {
                    var res = new OkObjectResult(new { message = "Failed To Update Product Record Not Found", currentDate = DateTime.Now, StatusCode = 404 });
                    return res;

                }
                else
                {
                    var res = new OkObjectResult(new { message = "Failed To Update Product Please check your code", currentDate = DateTime.Now, StatusCode = 501 });
                    return res;
                }
            }
            catch (Exception)
            {
                var res = new OkObjectResult(new { message = "Internal Server Error. Please contact support.", currentDate = DateTime.Now, StatusCode = 501 });
                return res;
            }
        }


        /* D */
        [HttpDelete]
        [Route("DeleteProduct/{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {

            try
            {
                var result = await _repository.DeleteProductAsync(ProductId);
                if (result == 200)
                {

                    var res = new OkObjectResult(new { message = "Successfully Deleted Record with ID" + ProductId, currentDate = DateTime.Now, StatusCode = 200 });
                    return res;
                }
                else if (result == 404)
                {
                    var res = new OkObjectResult(new { message = "Failed To Delete Product Record Not Found", currentDate = DateTime.Now, StatusCode = 404 });
                    return res;
                }
                else
                {
                    var res = new OkObjectResult(new { message = "Failed To Delete Product Please check your code", currentDate = DateTime.Now, StatusCode = 401 });
                    return res;

                }
            }
            catch (Exception)
            {
                var res = new OkObjectResult(new { message = "Internal Server Error. Please contact support.", currentDate = DateTime.Now, StatusCode = 500 });
                return res;
            }
        }



    }
}
