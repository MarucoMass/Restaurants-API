using Restaurants.Application.Models.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Services;

public interface IRestaurantsService
{
    Task<IEnumerable<RestaurantsDTO>> GetAllRestaurants();
    Task<RestaurantsDTO?> GetRestaurant(int id);
}