using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProductManager.API.Models;
using ProductManager.API.Repositories;
using ProductManager.API.Resources;
using ProductManager.API.Persistence;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace ProductManager.API.Services
{
    public class AuthenticationService: IAuthenticationService 
    {
    
	private readonly IUnitOfWork _unitOfWork;
    private readonly TokenConfiguration _tokenConfig;
    private readonly IAuthenticationRepository _authenticationRepository;

	public AuthenticationService(IUnitOfWork unitOfWork, TokenConfiguration tokenConfig, IAuthenticationRepository authenticationRepository)
	{
		_unitOfWork = unitOfWork;
        _tokenConfig = tokenConfig;
        _authenticationRepository = authenticationRepository;
	}
    
    public async Task<string> Login(LoginResource  sessionUser)
    {
        var user = await _authenticationRepository.VerifyUser(sessionUser);
        if (user == null)
            return null;
        return GenerateToken(user);
    }

         private string GenerateToken(User user)
        {
    

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString()),
                new Claim(nameof(user.IsActive), user.IsActive.ToString()),
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfig.Key));
            var signingCred = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials:signingCred,claims:claims, expires:DateTime.UtcNow.AddHours(1));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    public async Task RegisterUser(RegistrationResource  userDetails)
    {
        var newUser = new User { UserName = userDetails.UserName, Email = userDetails.Email, Password = userDetails.Password};
        await _authenticationRepository.RegisterNewUser(newUser);
        await _unitOfWork.CompleteAsync();
    }

    }
}   