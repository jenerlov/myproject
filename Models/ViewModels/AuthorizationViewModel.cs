using Microsoft.AspNetCore.Identity;

namespace myproject.Models.ViewModels
{
    public class AuthorizationViewModel
    {
        public IList<IdentityUser> Users {get; set;} = new List<IdentityUser>();
        public IList<IdentityUser> Admins {get; set;} = new List<IdentityUser>();
    }
}