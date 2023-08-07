using myproject.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace merketoaspnet.Helpers.Services;

public class UserAdminService
{
    private readonly UserManager<UserEntity> _userManager;


    public UserAdminService(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserAccount>> GetUsersAsync()
    {
    

        var users = new List<UserAccount>();
        foreach (var user in await _userManager.Users.ToListAsync())
        {
            var _userAccount = new UserAccount
            {
            
                Id = user.Id,
                Email = user.Email,

            };

            foreach(var role in await _userManager.GetRolesAsync(user))
            {
                _userAccount.NameOfRoles.Add(role);
            }

        

            users.Add(_userAccount);
        }
        return users;

    }

    public class UserAccount
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public List<string> NameOfRoles { get; set; } = new List<string>();
    }
}