using myproject.Helpers.Services;
using myproject.Models.Entities;
using myproject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace myproject.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly AuthenticationService _authenticationService;
        public RegistrationController(UserManager<UserEntity> userManager, AuthenticationService authenticationService)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
                {
                    if(await _authenticationService.RegisterUserAsync(viewModel))
                    return RedirectToAction("Index", "Login");
                }
                else
                    ModelState.AddModelError("", "A user with this email already exists");
            }
            return View(viewModel);
        }
    }
}