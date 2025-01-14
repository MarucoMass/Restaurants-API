﻿

using MediatR;
using Restaurants.Application.Dishes.DTOs;


namespace Restaurants.Application.Dishes.Querys.GetDishesForRestaurant;

public class GetDishesForRestaurantQuery(int restaurantId) : IRequest<IEnumerable<DishDTO>>
{
    public int RestaurantId { get; } = restaurantId;
}