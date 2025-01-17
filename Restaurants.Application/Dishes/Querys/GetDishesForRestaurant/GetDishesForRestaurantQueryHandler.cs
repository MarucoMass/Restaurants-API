﻿
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Querys.GetDishesForRestaurant;

public class GetDishesForRestaurantQueryHandler(
    ILogger<GetDishesForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper
    ) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDTO>>
{
    public async Task<IEnumerable<DishDTO>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dishes from restaurant with id: {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId );

        if (restaurant == null ) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var results = mapper.Map<IEnumerable<DishDTO>>(restaurant.Dishes);
        return results;
    }
}
