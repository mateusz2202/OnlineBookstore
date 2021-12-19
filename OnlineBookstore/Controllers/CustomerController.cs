using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<CustomerDTO>> GetAll()
        {
            var result=_customerService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> GetById([FromRoute] int id)
        {
            var result = _customerService.GetById(id);
            return Ok(result);
        }
        [HttpPost("register")]
        public ActionResult RegisterCustomer([FromBody] RegisterCustomerDTO dto)
        {
            _customerService.Create(dto);
            return Accepted();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO dto)
        {
            string token = _customerService.GenerateToken(dto);
            return Ok(token);
        }
    }
}
