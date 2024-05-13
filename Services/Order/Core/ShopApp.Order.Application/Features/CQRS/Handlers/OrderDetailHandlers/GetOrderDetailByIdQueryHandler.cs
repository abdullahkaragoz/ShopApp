using ShopApp.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using ShopApp.Order.Application.Features.CQRS.Results.OrderDetailResults;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            OrderDetail values = await repository.GetByIdAsync(query.Id);

            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailID = values.OrderDetailID,
                ProductAmount = values.ProductAmount,
                ProductName = values.ProductName,
                ProductPrice= values.ProductPrice,
                OrderingID = values.OrderingID,
                ProductTotalPrice = values.ProductTotalPrice,
            };
        }

    }
}
