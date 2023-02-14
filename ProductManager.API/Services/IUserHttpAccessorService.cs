using ProductManager.API.Models;
using ProductManager.API.Services.Communication;

namespace ProductManager.API.Services
{
    public interface IUserHttpAccessorService
    {
        string GetCurrentUserId();
    }

 }

