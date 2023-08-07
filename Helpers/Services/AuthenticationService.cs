using myproject.Helpers.Repositories;
using myproject.Models.Entities;
using myproject.Models.ViewModels;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace myproject.Helpers.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly AddressService _addressService;

        public AuthenticationService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressService addressService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _addressService = addressService;

        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel viewModel)
        {
            try
            {
                var createUser = await _userManager.CreateAsync(viewModel, viewModel.Password);
                if(createUser.Succeeded)
                {
                    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
                    await _userManager.AddToRoleAsync(user!, "user");

                    var matchAddress = await _addressService.GetOrCreateAddressAsync(viewModel);

                    return await _addressService.AddUserAddresses(user!.Id, matchAddress.Id);
                }
            }
            catch (Exception ex) {Debug.WriteLine(ex.Message);}
            return false;
        }
        public async Task<bool> LoginUserAsync(LoginViewModel viewModel)
        {
                    try
            {
                var loginRequest = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
                return loginRequest.Succeeded;

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        public async Task<bool> LogoutUserAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }
        }

    }
