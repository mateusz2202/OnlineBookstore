using Microsoft.AspNetCore.Authorization;
using OnlineBookstore.Entities;
using System.Security.Claims;

namespace OnlineBookstore.Authorization
{
    public class OrderOperationRequirmentHandler : AuthorizationHandler<OrderOperationRequirment, Order>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OrderOperationRequirment requirement, Order order)
        {
            var userId = context.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var role = context.User.FindFirst(x => x.Type == ClaimTypes.Role)?.Value;
            if (order.CustomerId == int.Parse(userId) || role == "Admin")
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
