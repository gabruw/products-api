using Domain.DTO;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Utils;
using System.Collections.Generic;

namespace Products.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            Response<IEnumerable<Order>> response = new Response<IEnumerable<Order>>();

            IEnumerable<Order> orders = _orderRepository.GetAll();
            response.Data = orders;

            return Ok(response);
        }

        [HttpPost]
        [Route("include")]
        public IActionResult Include([FromBody] OrderInclude orderInclude)
        {
            Response<Order> response = new Response<Order>();

            Order order = _orderRepository.Incluid(orderInclude.ToOrder());
            response.Data = order;

            return Ok(response);
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult Edit([FromBody] OrderEdit orderEdit)
        {
            Response<Order> response = new Response<Order>();

            Order order = _orderRepository.Update(orderEdit.ToOrder());
            response.Data = order;

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove")]
        public IActionResult Remove([FromQuery] long codigo)
        {
            Response<Order> response = new Response<Order>();

            Order order = _orderRepository.GetbyId(codigo);
            if (order == null)
            {
                response.Errors.Add(string.Format("O Código {0} não está cadastrado.", codigo));
                return BadRequest(response);
            }

            order = _orderRepository.Remove(order);
            response.Data = order;

            return Ok(response);
        }
    }
}
