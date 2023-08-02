using myproject.Models.ViewModels;
using myproject.Helpers.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace myproject.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactRepo _contactRepo;
        public ContactController(ContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactRepo.AddAsync(new Models.Entities.ContactFormEntity
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    Message = viewModel.Message
                }
                );
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
    }
}