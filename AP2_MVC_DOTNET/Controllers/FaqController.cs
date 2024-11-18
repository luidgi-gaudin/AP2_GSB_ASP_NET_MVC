using Microsoft.AspNetCore.Mvc;

namespace AP2_MVC_DOTNET.Controllers
{
  
    public class FaqController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }
    
    }
}