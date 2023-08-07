using myproject.Contexts;
using myproject.Models.Entities;

namespace myproject.Helpers.Repositories
{
    public class UserAddressRepo : GeneralRepo<UserAddressEntity>
    {
        public UserAddressRepo(DataContext context) : base(context)
        {}
    }
}