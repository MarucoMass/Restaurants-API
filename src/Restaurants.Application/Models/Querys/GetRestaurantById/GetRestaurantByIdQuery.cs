

using MediatR;
using Restaurants.Application.Models.DTOs;

namespace Restaurants.Application.Models.Querys.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantsDTO?>
{
    public int Id { get; } = id;
}
