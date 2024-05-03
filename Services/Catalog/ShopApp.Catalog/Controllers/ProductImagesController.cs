using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Catalog.Dtos.ProductImageDtos;
using ShopApp.Catalog.Services.ProductImageServices;

namespace ShopApp.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService productImageService;
        
        public ProductImagesController(IProductImageService productImageService)
        {
            this.productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImageList()
        {
            var values = await productImageService.GetAllProductImageAsync(); return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage Added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductImageDto updateProductImageDto)
        {
            await productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("ProductImage Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productImageService.DeleteProductImageAsync(id);
            return Ok("ProductImage Deleted");
        }


    }
}
