using Microsoft.Extensions.Logging;
using Restaurants.Application.Models.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantsDTO>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDTO = restaurants.Select(RestaurantsDTO.FromEntity);
        return restaurantsDTO!;
    }

    public async Task<RestaurantsDTO?> GetRestaurant(int id)
    {
        logger.LogInformation($"Getting restaurant {id}");
        var restaurant = await restaurantsRepository.GetAsync(id);
        var restaurantDTO = RestaurantsDTO.FromEntity(restaurant);
        return restaurantDTO;
    }
}
