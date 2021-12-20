using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;

namespace OnlineBookstore.Controllers
{
    [Route("api/shoppingbaskets")]
    [ApiController]
    public class ShoppingBasketController : ControllerBase
    {
        private readonly IShoppingBasketService _shoppingBasketService;

        public ShoppingBasketController(IShoppingBasketService shoppingBasketService)
        {
            _shoppingBasketService = shoppingBasketService;
        }

        [HttpGet]
        public ActionResult<ShoppingBasket> GetAll()
        {
           var result= _shoppingBasketService.GetAll();
            return Ok(result);
        }
    }
}
