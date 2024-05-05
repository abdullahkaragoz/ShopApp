﻿using Dapper;
using ShopApp.Discount.Context;
using ShopApp.Discount.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopApp.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext context;

        public DiscountService(DapperContext context)
        {
            this.context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into coupons (Code,Rate,IsActive,Validate) values (@code,@rate,@isActive,@validate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@valiDate", createCouponDto.ValidDate);
            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task DeleteCouponasync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * From Coupons";
            using var connection = context.CreateConnection();
            var values = await connection.QueryAsync<ResultCouponDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * from Coupons Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using var connection = context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query);
            return values;
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValiDate=@valiDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@valiDate", updateCouponDto.ValidDate);
            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
