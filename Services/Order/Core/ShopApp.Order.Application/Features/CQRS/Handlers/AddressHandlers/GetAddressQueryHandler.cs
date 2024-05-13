using ShopApp.Order.Application.Features.CQRS.Results.AddressResults;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressID = x.AddressID,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserID = x.UserID
            }).ToList();
        }



    }
}
