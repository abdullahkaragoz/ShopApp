using ShopApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await repository.GetByIdAsync(command.AddressID);
            values.Detail = command.Detail;
            values.District = command.District;
            values.City = command.City;
            values.UserID = command.UserID;
            await repository.UpdateAsync(values);
        }

    }
}
