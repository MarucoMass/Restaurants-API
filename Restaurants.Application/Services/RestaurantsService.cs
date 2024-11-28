using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Interfaces;
using Restaurants.Application.Models.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantsDTO>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();
        // FORMA SIN AUTOMAPPER
        //var restaurantsDTO = restaurants.Select(RestaurantsDTO.FromEntity);
        //return restaurantsDTO!;

        // FORMA CON AUTOMAPPER
        var restaurantDTO = mapper.Map<IEnumerable<RestaurantsDTO>>(restaurants);
        return restaurantDTO;
    }

    public async Task<RestaurantsDTO?> GetRestaurant(int id)
    {
        //logger.LogInformation($"Getting restaurant {id}");
        var restaurant = await restaurantsRepository.GetAsync(id);
        // FORMA SIN AUTOMAPPER
        //var restaurantDTO = RestaurantsDTO.FromEntity(restaurant);
        //return restaurantDTO;

        // FORMA CON AUTOMAPPER
        var restaurantDTO = mapper.Map<RestaurantsDTO?>(restaurant);
        return restaurantDTO;
    }
}
