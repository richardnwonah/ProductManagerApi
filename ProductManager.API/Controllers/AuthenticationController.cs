using Microsoft.AspNetCore.Mvc;
using ProductManager.API.Services;
using ProductManager.API.Models;
using ProductManager.API.Extensions;
using ProductManager.API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ProductManager.API.Controllers
{
    [Route("/api/[controller]")]
    public class AuthenticationController : Controller
    {
         private readonly IAuthenticationService _authenticationService;
         private readonly IMapper _mapper;
         private readonly IUserHttpAccessorService _userHttpAccessorService;
        
        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper, IUserHttpAccessorService userHttpAccessorService)
        {
            _authenticationService = authenticationService;
            _userHttpAccessorService = userHttpAccessorService;
            _mapper = mapper;
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginResource user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());    
            var token = await _authenticationService.Login(user);
            if (token == null)
                 return BadRequest();
            return Ok(token);
        }

        [Authorize]
        [HttpGet("get-my-id")]
        public ActionResult<string> GetMyId()
        {
            return _userHttpAccessorService.GetCurrentUserId();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationResource user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            await _authenticationService.RegisterUser(user);
            return Ok();
          
        }

    }
}