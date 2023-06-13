using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myproject.ViewModels;

namespace myproject.Controllers
{

    public class HomeController : Controller
    {
public IActionResult Index()
{
    
    HomeIndexViewModel model = new HomeIndexViewModel();
    // Populate the model properties as needed
    model.Title = "Example Title";

    return View(model);
}


    }
}