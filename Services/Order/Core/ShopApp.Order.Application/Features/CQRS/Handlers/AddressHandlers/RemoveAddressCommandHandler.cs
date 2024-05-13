using ShopApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> repository;
        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            var value = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(value);
        }
    }
}
