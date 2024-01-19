
using LibraryManagement.Domain.Entities.RegularEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagement.Application.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var allowAnonymous = filterContext.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            if (allowAnonymous)
            {
                return;
            }

            var user = filterContext.HttpContext.Items["User"] as User;

            if (user == null)
            {
                filterContext.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        }
    }
}
