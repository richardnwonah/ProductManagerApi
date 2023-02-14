using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManager.API.Models;
using ProductManager.API.Repositories;
using ProductManager.API.Data;
using ProductManager.API.Resources;

namespace ProductManager.API.Repositories
{
    public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {
        public AuthenticationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> VerifyUser(LoginResource sessionUser)
        {
            User user = _context.Users.FirstOrDefault(x=> x.Email.Equals(sessionUser.Email) && x.Password.Equals(sessionUser.Password));
            if(user == null)
                return null;
            return(user);
        }
        public async Task RegisterNewUser(User newUser)
        {
            _context.Users.Add(newUser);
            
        }
    }
}