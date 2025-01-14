﻿using MediatR;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Dishes.Querys.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDTO>
{
    public int RestaurantId { get; } = restaurantId;
    public int DishId { get; } = dishId;
}