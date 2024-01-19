using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LibraryManagement.Application.Security.Utils
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var AuthentificatedUserData = jwtUtils.ValidateToken(token);
            
            if (AuthentificatedUserData != null)
            {
                context.Items["User"] = await userService.GetById(AuthentificatedUserData.UserId);
            }

            await _next(context);
        }
    }
}
