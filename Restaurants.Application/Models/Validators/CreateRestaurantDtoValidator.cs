

using FluentValidation;
using Restaurants.Application.Models.DTOs;

namespace Restaurants.Application.Models.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDTO>
{
    private readonly List<string> validCategories = ["American", "Indian", "Latin"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name).Length(3, 100);

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            //.Custom((value, context) =>
            //{
            //    var isValidCategory = validCategories.Contains(value);
            //    if (!isValidCategory)
            //    {
            //        context.AddFailure("Category", "Invalid category: Please choose one of the valid categories");
            //    }
            //})
            .WithMessage("Please choose one of the valid categories");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress()
            .WithMessage("Please insert a valid email");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Please insert a valid postal code format: XX-XXX");
    }
}
