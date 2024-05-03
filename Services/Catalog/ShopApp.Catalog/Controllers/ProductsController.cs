using Microsoft.AspNetCore.Mvc;
using ShopApp.Catalog.Dtos.ProductDtos;
using ShopApp.Catalog.Services.ProductServices;

namespace ShopApp.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await productService.GetByIdProductAsync(id);
            return Ok(values);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await productService.CreateProductAsync(createProductDto);  
            return Ok("Product Added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await productService.UpdateProductAsync(updateProductDto);
            return Ok("Product Updated");
        }

        [HttpDelete] 
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id); return Ok("Product Deleted");
        }

    }
}