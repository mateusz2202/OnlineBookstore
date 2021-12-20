using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookstore.Controllers
{
    [Route("api/instancebooks")]
    [ApiController]
    public class InstanceBookController : ControllerBase
    {
        private readonly IInstanceBookService _instanceBookService;

        public InstanceBookController(IInstanceBookService instanceBookService)
        {
            _instanceBookService = instanceBookService;
        }

        [HttpGet]
        public ActionResult<List<InstanceBookDTO>> GetAll()
        {
            var result=_instanceBookService.GetAll();
            return Ok(result);
        }

      
        [HttpGet("{id}")]
        public ActionResult<InstanceBookDTO> GetById([FromRoute]int id)
        {
            var result = _instanceBookService.GetById(id);
            return Ok(result);
        }

       
        [HttpPost]
        public ActionResult Create([FromBody] CreateInstanceBookDTO dto)
        {
            _instanceBookService.Create(dto);
            return Ok(); 
        }

        // PUT api/<InstanceBookController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstanceBookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
