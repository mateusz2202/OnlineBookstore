using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult<List<OrderDTO>> GetAll()
        {
            var result=_orderService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetById([FromRoute] int id)
        {
            var result = _orderService.GetById(id);
            return Ok(result);
        }
    }
}
