
using MediatR;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Querys.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantsDTO>>
{
}
