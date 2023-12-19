using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Controllers
{
    public class AdminPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
