
using MediatR;
using Restaurants.Application.Models.DTOs;

namespace Restaurants.Application.Models.Querys.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantsDTO>>
{
}
