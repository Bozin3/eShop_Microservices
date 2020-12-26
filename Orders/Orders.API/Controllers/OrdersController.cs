using System.Threading.Tasks;
using eShop_Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Repositories;

namespace Orders.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            return Ok(await ordersRepository.GetOrders());
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var order = await ordersRepository.GetOrder(id);
           
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult> PostOrder(Order order)
        {
            await ordersRepository.AddOrder(order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteOrder(int id)
        {
            var order = await ordersRepository.GetOrder(id);
            
            if (order == null)
            {
                return NotFound();
            }

            await ordersRepository.DeleteOrder(order);
           
            return Ok(order);
        }

    }
}