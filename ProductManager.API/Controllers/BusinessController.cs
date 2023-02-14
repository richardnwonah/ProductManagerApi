using Microsoft.AspNetCore.Mvc;
using ProductManager.API.Services;
using ProductManager.API.Models;
using ProductManager.API.Extensions;
using ProductManager.API.Resources;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ProductManager.API.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class BusinessController : Controller
    {
         private readonly IBusinessService _businessService;
         private readonly IMapper _mapper;
         private readonly IUserHttpAccessorService _userHttpAccessorService;
        
        public BusinessController(IBusinessService businessService, IMapper mapper, IUserHttpAccessorService userHttpAccessorService)
        {
            _businessService = businessService; 
            _userHttpAccessorService = userHttpAccessorService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<BusinessResource> GetBusinessById(int id)
        {
            var userId = _userHttpAccessorService.GetCurrentUserId();
            var Business = await _businessService.GetUserBusinessByIdAsync(id, userId);
            var resource = _mapper.Map<Business,  BusinessResource> (Business);
            return resource;
        }

        [HttpGet]
        public async Task<IEnumerable<BusinessResource>> GetAllAsync()
        {
            var userId = _userHttpAccessorService.GetCurrentUserId();
            var Business = await _businessService.ListAsync(userId);
            var resources = _mapper.Map<IEnumerable<Business>, IEnumerable<BusinessResource>> (Business);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBusinessResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var userId = _userHttpAccessorService.GetCurrentUserId();
            var business = _mapper.Map<SaveBusinessResource, Business>(resource);
            var result = await _businessService.SaveAsync(business, userId);
            

            if (!result.Success)
                return BadRequest(result.Message);

            var businessResource = _mapper.Map<Business, BusinessResource>(result.Business);
            return Ok(businessResource);


            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            { 
                IEnumerable<Claim> claims = identity.Claims;

            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBusinessResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var business = _mapper.Map<SaveBusinessResource, Business>(resource);
            var result = await _businessService.UpdateAsync(id, business);

            if (!result.Success)
                return BadRequest(result.Message);

            var businessResource = _mapper.Map<Business, BusinessResource>(result.Business);
            return Ok(businessResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _businessService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var businessResource = _mapper.Map<Business, BusinessResource>(result.Business);
            return Ok(businessResource);
        }
    }
}