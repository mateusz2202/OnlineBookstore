using Microsoft.AspNetCore.Authorization;
using OnlineBookstore.Entities;
using System.Security.Claims;

namespace OnlineBookstore.Authorization
{
  
    public class ResourceOperationRequirementHandler :AuthorizationHandler<ResourceOperationRequirement,Customer>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Customer customer)
        {            
            var userId = context.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if(customer.Id == int.Parse(userId))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
