using ShopApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using ShopApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await repository.GetByIdAsync(command.OrderDetailID);
            values.OrderingID = command.OrderingID;
            values.ProductID = command.ProductID;
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProductAmount = command.ProductAmount;
            await repository.UpdateAsync(values);   
        }

    }
}
