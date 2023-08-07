using System.ComponentModel.DataAnnotations;

namespace myproject.Models.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;} = null!;


        [DataType(DataType.Password)]
        public string Password {get; set;} = null!;

        public bool RememberMe {get; set;}
    }
}