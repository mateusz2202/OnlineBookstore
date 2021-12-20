using Microsoft.AspNetCore.Authorization;

namespace OnlineBookstore.Authorization
{
    public class OrderOperationRequirment : IAuthorizationRequirement
    {
        public OrderOperationRequirment()
        {

        }
    }
}
