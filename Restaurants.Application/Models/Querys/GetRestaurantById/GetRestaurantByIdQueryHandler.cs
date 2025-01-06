
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Models.Commands.CreateRestaurant;
using Restaurants.Application.Models.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Models.Querys.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(ILogger<CreateRestaurantCommand> logger, 
    IMapper mapper, 
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantsDTO?>
{
    public async Task<RestaurantsDTO?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting restaurant {request.Id}");
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        var restaurantDTO = mapper.Map<RestaurantsDTO?>(restaurant);
        return restaurantDTO;
    }
}
