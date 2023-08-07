using myproject.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace merketoaspnet.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; } = null!;



        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; } = null!;



        [Display(Name = "Email")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email address is not formatted correctly")]
        public string Email { get; set; } = null!;



        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Password must be strong, please choose a better password")]
        public string Password { get; set; } = null!;


        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "This field is required")]
        public string StreetName { get; set; } = null!;


        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; } = null!;


        [Display(Name = "City")]
        [Required(ErrorMessage = "This field is required")]
        public string City { get; set; } = null!;



        public static implicit operator UserEntity(RegisterViewModel viewModel)
        {
            return new UserEntity
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                UserName = viewModel.Email,

            };
        }

        public static implicit operator AddressEntity(RegisterViewModel viewModel)
        {
            return new AddressEntity
            {
                StreetName = viewModel.StreetName,
                PostalCode = viewModel.PostalCode,
                City = viewModel.City,
            };
        }
    }
}