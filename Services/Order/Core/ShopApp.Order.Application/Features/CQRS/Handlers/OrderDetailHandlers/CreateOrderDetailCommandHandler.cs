using ShopApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await repository.CreateAsync(new OrderDetail
            {
                OrderDetailID = command.OrderDetailID,
                OrderingID = command.OrderingID,
                ProductAmount = command.ProductAmount,
                ProductPrice = command.ProductPrice,
                ProductID = command.ProductID,
                ProductName = command.ProductName,
            });
        }
    }
}
