using ShopApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var value = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(value);
        }
    }
}
