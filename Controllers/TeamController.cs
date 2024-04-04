using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
