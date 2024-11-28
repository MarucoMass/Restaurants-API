using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Interfaces;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var restaurants = await restaurantsService.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var restaurant = await restaurantsService.GetRestaurant(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

    }
}
