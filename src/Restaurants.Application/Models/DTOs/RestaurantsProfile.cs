
using AutoMapper;
using Restaurants.Application.Models.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Models.DTOs;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(r => r.Address, opt => opt.MapFrom(src => new Address
            {
                City = src.City,
                Street = src.Street,
                PostalCode = src.PostalCode
            }));

        CreateMap<Restaurant, RestaurantsDTO>()
            .ForMember(r => r.City, option => option.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(r => r.Street, option => option.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(r => r.PostalCode, option => option.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(r => r.Dishes, option => option.MapFrom(src => src.Dishes));
    }
}
