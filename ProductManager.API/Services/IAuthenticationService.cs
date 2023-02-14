
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Resources;
using ProductManager.API.Services.Communication;

namespace ProductManager.API.Services
{
    public interface IAuthenticationService
    {
       Task<string> Login(LoginResource sessionUser);
       Task RegisterUser(RegistrationResource  newUser);
       
    }

 }

