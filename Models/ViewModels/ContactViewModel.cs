using System.ComponentModel.DataAnnotations;

namespace myproject.Models.ViewModels
{
    public class ContactViewModel
    {

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName {get; set;} = null!;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string LastName {get; set;} = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email address is not formatted correctly")]
        public string Email {get; set;} = null!;

        [Required(ErrorMessage = "This field is required")]
        public string Message {get; set;} = null!;

    }
}
