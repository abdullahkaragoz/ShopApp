using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Catalog.Dtos.ProductDetailDtos;
using ShopApp.Catalog.Services.ProductDetailServices;

namespace ShopApp.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            this.productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await productDetailService.GetAllProductDetailAsync(); return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await productDetailService.GetByIdProductDetailAsync(id); return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
           await productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail Added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail Deleted");
        }

    }
}
