using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;
using System.Security.Claims;

namespace OnlineBookstore.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [Authorize]   
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(Roles="Admin")]
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

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult RegisterCustomer([FromBody] RegisterCustomerDTO dto)
        {
            _customerService.Create(dto);
            return Accepted();
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO dto)
        {
            string token = _customerService.GenerateToken(dto);
            return Ok(token);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id,[FromBody] UpdateCustomerAboutDTO dto  )
        {
            _customerService.Update(id, dto);
            return Ok();
        }
        [HttpPut("{id}/changePassword")]
        public ActionResult ChangePassword([FromRoute]int id,[FromBody] UpdateCustomerPasswordDTO dto)
        {
            _customerService.ChangePassword(id, dto);
            return Ok();
        }

    }
}
