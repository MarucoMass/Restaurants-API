
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Querys.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(
    ILogger<CreateRestaurantCommand> logger, 
    IMapper mapper, 
    IRestaurantsRepository restaurantsRepository) 
    : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantsDTO>>
{
    public async Task<PagedResult<RestaurantsDTO>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");

        var (restaurants, totalCount) = await restaurantsRepository.GetAllMatchingAsync(
            request.SearchPhrase, 
            request.PageSize, 
            request.PageNumber, 
            request.SortBy,
            request.SortDirection);

        var restaurantsDTO = mapper.Map<IEnumerable<RestaurantsDTO>>(restaurants);

        var result = new PagedResult<RestaurantsDTO>(restaurantsDTO, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
