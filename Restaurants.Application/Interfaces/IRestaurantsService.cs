
using Restaurants.Application.Models.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Interfaces;

public interface IRestaurantsService
{
    Task<IEnumerable<RestaurantsDTO>> GetAllRestaurants();
    Task<RestaurantsDTO?> GetRestaurant(int id);

    Task<int> Create(CreateRestaurantDTO createRestaurantDTO);
}