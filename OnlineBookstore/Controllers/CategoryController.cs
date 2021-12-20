using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers
{
    [Route("api/categories")]
    [ApiController]   
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<CategoryDTO>> GetAll()
        {
            var result=_categoryService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetById([FromRoute]int id)
        {
            var result = _categoryService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([FromBody] CreateCategoryDTO dto)
        {
            _categoryService.Create(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromRoute]int id,[FromBody] CreateCategoryDTO dto)
        {
            _categoryService.Update(id,dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }


    }
}
