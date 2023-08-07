using myproject.Helpers.Services;
using myproject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace myproject.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthenticationService _authenticationService;

        public LoginController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (ModelState.IsValid && viewModel.Email.Contains("administrator")) 
            {
                if (await _authenticationService.LoginUserAsync(viewModel))
                {
                        return RedirectToAction("Index", "Administrator");
                }
                
            }
            else if (ModelState.IsValid)
            {
                if (await _authenticationService.LoginUserAsync(viewModel))
                {
                    return RedirectToAction("Index", "User");
                }


            }
            if (ModelState.IsValid)
            { 
            if  (!await _authenticationService.LoginUserAsync(viewModel))
                
                return RedirectToAction("Index", "AccessDenied");
            }



            return View(viewModel);
        }
    }
}