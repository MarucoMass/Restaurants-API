using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.DTOs.CreateRestaurantDTO;

public class CreateRestaurantDTO
{
    //[StringLength(100, MinimumLength = 3)]
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;

    //[Required(ErrorMessage = "Insert a valid category")]
    public string? Category { get; set; } = default!;
    public bool HasDelivery { get; set; }

    //[EmailAddress(ErrorMessage = "Please insert a valid email")]
    public string? ContactEmail { get; set; }

    [Phone(ErrorMessage = "Please insert a valid phone number")]
    public string? ContactNumber { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }

    //[RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Insert a valid postal code: XX-XXX")]
    public string? PostalCode { get; set; }
}