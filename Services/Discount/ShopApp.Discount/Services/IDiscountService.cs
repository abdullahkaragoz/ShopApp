using ShopApp.Discount.Dtos;

namespace ShopApp.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponasync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    }
}
