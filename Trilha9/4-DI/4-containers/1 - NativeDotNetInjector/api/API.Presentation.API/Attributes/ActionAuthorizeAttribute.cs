using API.Domain.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace API.Presentation.API.Attributes
{
    public class ActionAuthorizeAttribute : AuthorizeAttribute
    {
        public ActionAuthorizeAttribute(ActionRoles roles)
        {
            this.Policy = $"Role_{roles.ToString("g")}";
        }
    }
}
