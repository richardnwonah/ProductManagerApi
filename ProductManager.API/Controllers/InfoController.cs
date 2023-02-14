using Microsoft.AspNetCore.Mvc;


namespace ProductManager.API.Controllers
{
    [Route("/api/[controller]")]
    public class InfoController : Controller
    {
       public InfoController()
        {
          
        }

    
        [HttpGet]
        public IActionResult Get()
        {
            var Name = "Richard Nwonah";
            Response.StatusCode = 200;
            return Json(new { developer = Name });
        }

    }
}