using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ActionResult<List<AuthorDTO>> GetAll()
        {
            var result=_authorService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<List<AuthorDTO>> GetById([FromRoute] int id)
        {
            var result = _authorService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateAuthorDTO dto)
        {
            _authorService.Create(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id,[FromBody] CreateAuthorDTO dto)
        {
            _authorService.Update(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _authorService.Delete(id);
            return NoContent();
        }
    }
}
