using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ShopApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using ShopApp.Order.Application.Features.CQRS.Queries.AddressQueries;
using ShopApp.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace ShopApp.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
        {
            this.getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            this.getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            this.createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            this.removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
            this.updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value = await getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await updateOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş başarıyla güncellendi.");
        }

    }
}
