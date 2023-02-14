using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace ProductManager.API.Services
{
    public class UserHttpAccessorService: IUserHttpAccessorService
    {
            private readonly IHttpContextAccessor _httpContextAccessor;
            public UserHttpAccessorService(IHttpContextAccessor httpContextAccessor )
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string GetCurrentUserId()
            {
                var userId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x =>
                 x.Type == ClaimTypes.NameIdentifier)?.Value;

                 return userId;
            }
    }

}   