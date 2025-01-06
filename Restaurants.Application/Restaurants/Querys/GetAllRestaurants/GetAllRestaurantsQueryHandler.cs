﻿
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Querys.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(ILogger<CreateRestaurantCommand> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantsDTO>>
{
    public async Task<IEnumerable<RestaurantsDTO>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantDTO = mapper.Map<IEnumerable<RestaurantsDTO>>(restaurants);
        return restaurantDTO;
    }
}
