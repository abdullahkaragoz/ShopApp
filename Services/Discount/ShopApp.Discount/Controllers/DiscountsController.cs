using Microsoft.AspNetCore.Mvc;
using ShopApp.Discount.Dtos;
using ShopApp.Discount.Services;

namespace ShopApp.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService discountService;

        public DiscountsController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await discountService.GetAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var values = await discountService.GetByIdCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon Added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await discountService.DeleteCouponasync(id);
            return Ok("Coupon Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon Updated");
        }


    }
}
