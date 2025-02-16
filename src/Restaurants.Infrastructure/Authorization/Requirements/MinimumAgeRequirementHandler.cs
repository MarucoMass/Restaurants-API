

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;

namespace Restaurants.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirementHandler(
    ILogger<MinimumAgeRequirementHandler> logger,
    IUserContext userContext
    ) : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, 
        MinimumAgeRequirement requirement)
    {
        var user = userContext.GetCurrentUser();

        logger.LogInformation("User: {Email}, Date of birth: {DoB}. Handling min age requirement", user!.Email, user.DateOfBirth);

        if(user.DateOfBirth is null)
        {
            logger.LogWarning("User date of birth is null");
            context.Fail();
            return Task.CompletedTask;
        }

        if(user.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
        {
            logger.LogInformation("Successful auth");
            context.Succeed(requirement);
        } else
        {
            context.Fail();
        }

        return Task.CompletedTask;

    }
}
