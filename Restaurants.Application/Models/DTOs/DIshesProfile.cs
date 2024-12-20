
using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Models.DTOs;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDTO>();
    }
}
