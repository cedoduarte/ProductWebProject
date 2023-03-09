using BackendProduct.CQRS.Products.Command.InsertProduct;
using BackendProduct.CQRS.Products.Command.UpdateProduct;
using BackendProduct.CQRS.Products.Query.GetProductList;
using BackendProduct.CQRS.Products.ViewModel;
using BackendProduct.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BackendProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// Inserts new "product" into "database"
        [HttpPost("insertProduct")]
        public async Task<bool> InsertProduct([FromBody] InsertProductCommand command)
        {
            try
            {
                return await _productService.InsertProduct(command);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Updates a "product" from its "id"
        [HttpPut("updateProduct")]
        public async Task<bool> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            try
            {
                return await _productService.UpdateProduct(command);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Deletes a "product" from its "id"
        [HttpDelete("deleteProduct/{id}")]
        public async Task<bool> DeleteProduct([FromRoute] int id)
        {
            try
            {
                return await _productService.DeleteProduct(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Returns the found "products"
        [HttpGet("getProductList")]
        public async Task<IEnumerable<ProductViewModel>> GetProductList([FromQuery] GetProductListQuery query)
        {
            try
            {
                return await _productService.GetProductList(query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Returns the found "product" by its "id"
        [HttpGet("getProductById/{id}")]
        public async Task<ProductViewModel> GetProductById(int id)
        {
            try
            {
                return await _productService.GetProductById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
