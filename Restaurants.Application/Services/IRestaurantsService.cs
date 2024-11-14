using Restaurants.Domain.Entities;

namespace Restaurants.Application.Services;

public interface IRestaurantsService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
}