using ShopApp.Order.Application.Features.CQRS.Results.AddressResults;
using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Domain.Entities;

namespace ShopApp.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task<GetAddressQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await repository.GetByIdAsync(query.Id);
            return new GetAddressQueryResult
            {
                AddressID = values.AddressID,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserID = values.UserID
            };
        }
    }
}
