using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace myproject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}