using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Resources;

namespace ProductManager.API.Repositories
{
    public interface IAuthenticationRepository
    {
       Task<User> VerifyUser(LoginResource sessionUser);
        Task RegisterNewUser(User newUser);
    }
}