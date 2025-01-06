

using MediatR;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Querys.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantsDTO?>
{
    public int Id { get; } = id;
}
